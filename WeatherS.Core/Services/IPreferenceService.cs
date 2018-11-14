using System;
using System.Collections.Generic;
using System.Text;
using WeatherS.Core.Enums;

namespace WeatherS.Core.Services
{
    public interface IPreferenceService
    {
        void SaveValue(PreferenceType key, string value);
        string GetValue(PreferenceType key);
    }
}
