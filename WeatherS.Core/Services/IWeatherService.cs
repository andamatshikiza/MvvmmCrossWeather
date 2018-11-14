using System.Threading.Tasks;
using WeatherS;

namespace WeatherS.Core.Services
{
    public interface IWeatherService
    {
        Task<WeatherInfo.RootObject> GetWeather(string cityName);
    }
}
