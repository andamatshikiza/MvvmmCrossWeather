using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherS.Core.Services
{
    public interface ISystemCacheService
    {
        WeatherInfo.RootObject WeatherDetails { get; set; }
    }
}
