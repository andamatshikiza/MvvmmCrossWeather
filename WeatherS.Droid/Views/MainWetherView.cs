using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using WeatherS.Core.ViewModels;

namespace WeatherS.Droid.Views
{
    [Activity(Label = "Weather App", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainWeatherView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainVWeatherView);
        }
    }
}