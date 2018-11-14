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
using WeatherS.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace WeatherS.Droid.Views
{
    [Activity(Label = "Weather App", MainLauncher = false, Theme = "@style/AppTheme")]
    public class WeatherDetailsView : MvxActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Details);
        }
    }
}