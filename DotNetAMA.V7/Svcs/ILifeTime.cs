﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.V7.Svcs
{
    public interface ILifeTime
    {
        /// <summary>
        /// 요청아이디
        /// </summary>
        string _requestId { get; }
    }
}
