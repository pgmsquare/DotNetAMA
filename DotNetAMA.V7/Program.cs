using DotNetAMA.V7.Data;
using DotNetAMA.V7.Extensions;
using DotNetAMA.V7.Svcs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // 이전의 logger 제공자들을 지우고
    // NLog logger로 사용하겠다.
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    builder.Logging.AddFilter("", LogLevel.Trace);
    //builder.Logging.AddFilter("", LogLevel.Debug);
    builder.Host.UseNLog(); // Dependency Injection
    
    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddSingleton<DotNetAMA.V7.Svcs.ILogger, LoggerService>();

    builder.Services.AddSingleton<ISingletonLifeTime, LifeTimeService>();
    builder.Services.AddScoped<IScopedLifeTime, LifeTimeService>();
    builder.Services.AddTransient<ITransientLifeTime, LifeTimeService>();

    builder.Services.AddScoped<IEmployee, EmployeeDapperService>();

    /*
    builder.Services.AddSingleton<interface, class>();
    builder.Services.AddScoped<interface, class>();
    builder.Services.AddTransient<interface, class>();

    Singleton : 아무리 많이 요청받아도 모두 동일하게
                값을 유지해야 되는 서비스
    Scoped : 요청될 때마다 값이 바뀌어야 하는 서비스
    Transient : 매번 값이 바뀌어야 하는 서비스
    */

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //app.UseMiddleware<LifeTimeMiddleware>();
    app.UseLifeTimeLogger();

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // NLog 종료
    NLog.LogManager.Shutdown();
}