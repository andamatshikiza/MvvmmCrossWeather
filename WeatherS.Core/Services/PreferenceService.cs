using System;
using System.Collections.Generic;
using System.Text;
using WeatherS.Core.Enums;
using Xamarin.Essentials;
using Java.Util.Prefs;
using Preferences = Xamarin.Essentials.Preferences;

namespace WeatherS.Core.Services
{
    public class PreferenceService : IPreferenceService
    {
        public string GetValue(PreferenceType key)
        {
            return Preferences.Get(key.ToString(), string.Empty);
        }

        public void SaveValue(PreferenceType preferenceType, string value)
        {
            Preferences.Set(preferenceType.ToString(), value);
        }
    }
}
