using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherS;

namespace WeatherS.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather?q=";
        private const string UrlQueryString = "&units=metric&appid=c2e506d0ce81d37f542d0e2a0237e468";
        private readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        public async Task<WeatherInfo.RootObject> GetWeather(string cityName)
        {
            WeatherInfo.RootObject result = null;
            try
            {
                var url = BaseUrl + cityName + UrlQueryString;
                var json = await httpClient.GetAsync(url);
                if (json.IsSuccessStatusCode)
                {
                    var jsonContent = await json.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<WeatherInfo.RootObject>(jsonContent);
                }
            }
            catch (System.Exception)
            {

            }
            return result;
        }
    }

    }

