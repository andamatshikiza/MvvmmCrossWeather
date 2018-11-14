using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherS.Core.Services;
using WeatherS.Core.ViewModels;

namespace WeatherS.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {


            Mvx.IoCProvider.RegisterType<IWeatherService, WeatherService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISystemCacheService, SystemCacheService>();

            RegisterAppStart<MainViewModel>();

        }
    }

    }

