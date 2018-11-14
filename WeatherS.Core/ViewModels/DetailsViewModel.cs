using Java.Sql;
using Java.Text;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherS.Core.Presentation;
using WeatherS.Core.Services;

namespace WeatherS.Core.ViewModels
{

    public class DetailsViewModel : MvxViewModel
    {
        private readonly ISystemCacheService _systemCache;
        readonly string _url = "http://openweathermap.org/img/w/";

        public DetailsViewModel(ISystemCacheService systemCache)
        {
            //MyListItems = new List<WeatherDetail>();
            _systemCache = systemCache;

        }
        public string CityName { get; private set; }
        public string Country { get; private set; }
        public string Temperature { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
        public string IconUrl { get; private set; }
        public string Date_Time { get; private set; }
        public string Cloudiness { get; private set; }
        public string Wind { get; private set; }
        public string Pressure { get; private set; }
        public string Humidity { get; private set; }
        public string Sunrise { get; private set; }
        public string Sunset { get; private set; }
        public string Coords { get; private set; }


         public List<WeatherDetails> MyListItems { get; private set; }

        public override void Start()
        {
            base.Start();
            var result = _systemCache.WeatherDetails;

            Country = result.Sys.Country;
            CityName = "Weather in " + result.Name + ", " + Country;
            Icon = result.Weather[0].Icon;
            IconUrl = _url + Icon + ".png";
            Temperature = result.Main.Temperature + " \u2103";

            Date dt = new Date(Convert.ToInt64(result.Lastupdate) * 1000);
            SimpleDateFormat sfd = new SimpleDateFormat("yyyy/MM/dd HH:mm");
            Date_Time = sfd.Format(dt).ToString();
            Description = result.Weather[0].Description + "\n" + "Updated at " + Date_Time;

            Wind = result.Wind.Speed;
            Cloudiness = result.Clouds.All;
            Pressure = result.Main.Pressure;
            Humidity = result.Main.Humidity;

            Date dtSunrise = new Date(Convert.ToInt64(result.Sys.Sunrise) * 1000);
            SimpleDateFormat sfdSunrise = new SimpleDateFormat("HH:mm");
            Sunrise = sfdSunrise.Format(dtSunrise).ToString();

            Date dtSunset = new Date(Convert.ToInt64(result.Sys.Sunset) * 1000);
            SimpleDateFormat sfdSunset = new SimpleDateFormat("HH:mm");
            Sunset = sfdSunset.Format(dtSunset).ToString();

            Coords = "[" + result.Coordinate.Latitude + ", " + result.Coordinate.Longitude + "]";

         MyListItems.Add(new WeatherDetails("Wind", Wind + " km/h"));
         MyListItems.Add(new WeatherDetails("Cloudiness", Cloudiness + " %"));
         MyListItems.Add(new WeatherDetails("Pressure", Pressure + " hpa"));
         MyListItems.Add(new WeatherDetails("Humidity", Humidity + " %"));
         MyListItems.Add(new WeatherDetails("Sunrise", Sunrise));
         MyListItems.Add(new WeatherDetails("Sunset", Sunset));
         MyListItems.Add(new WeatherDetails("Coords", Coords));
        }
    }
}
    

