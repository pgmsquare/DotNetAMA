using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.Svcs
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
