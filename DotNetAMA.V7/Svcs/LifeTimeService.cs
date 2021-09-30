namespace DotNetAMA.V7.Svcs
{
    public class LifeTimeService : ISingletonLifeTime,
                                   IScopedLifeTime,
                                   ITransientLifeTime
    {
        public LifeTimeService()
        {
            _requestId = Guid.NewGuid().ToString();
        }

        public string _requestId { get; }
    }
}
