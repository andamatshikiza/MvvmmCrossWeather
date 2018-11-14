using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherS.Core.Services;
namespace WeatherS.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IWeatherService _weatherService;
        private readonly ISystemCacheService _systemCache;
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IWeatherService weatherService, ISystemCacheService systemCache, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = weatherService;
            _systemCache = systemCache;

            MyCommand = new MvxAsyncCommand(DoMyCommand, MyCommandCanExecute);
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                SetProperty(ref _city, value);
                MyCommand.RaiseCanExecuteChanged();
            }
        }

        public bool MyCommandCanExecute()
        {
            return !string.IsNullOrEmpty(City);
        }
        public MvxAsyncCommand MyCommand { get; }
        private async Task DoMyCommand()
        {
            try
            {
                var result = await _weatherService.GetWeather(City);
                if (result != null)
                {
                    _systemCache.WeatherDetails = result;

                    await _navigationService.Navigate<DetailsViewModel>();
                }
            }
            finally { }

        }
    }
    }
