using System;
using System.Collections.Generic;

namespace WeatherAPI.Data
{
    public abstract class EndPointBaseClass
    {
        public string EndPoint { get; set; }
        public Dictionary<string, Tuple<string, string, bool>> Parameters { get; set; }
    }
}