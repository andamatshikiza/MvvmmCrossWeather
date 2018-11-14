using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherS.Core.Services
{
    public class SystemCacheService : ISystemCacheService
    {
        public WeatherInfo.RootObject WeatherDetails { get; set; }
    }
}
