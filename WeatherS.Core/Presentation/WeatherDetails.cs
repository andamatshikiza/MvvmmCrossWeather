using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherS.Core.Presentation
{
   public class WeatherDetails
    {

        public WeatherDetails(string title, string value)
        {
            Title = title;
            Value = value;
        }

        public string Title { get; }
        public string Value { get; }
    }
}
}
