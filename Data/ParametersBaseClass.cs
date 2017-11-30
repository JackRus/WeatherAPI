using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherAPI.Data
{
    public abstract class ParametersBaseClass
    {
        protected string Url;
        internal string EndPoint;
        protected readonly string EndPointBase = "https://www.ncdc.noaa.gov/cdo-web/api/v2/";
        
        public string Limit { get; set; }
        public string OffSet { get; set; }
        public string From { get; set; }      
        public string To { get; set; }        
        public string SortBy { get; set; }      
        public string Order { get; set; }
        
        public abstract string BuildUrl ();
        
        public void checkUrl()
        {
            // adds '?' to the end of the url
            if (this.Url.IndexOf('?') < 0) {
                this.Url += "?";
            }
            
            string lastChar = this.Url.Substring(this.Url.Length - 1);
            this.Url += (lastChar != "&" && lastChar != "?") ? "&" : "";
        }

        public void checkValue (string name, string value)
        {
            if(!String.IsNullOrEmpty(value)){
                checkUrl();
                this.Url += $"{name}={value}";
            }
        }

        public string ToJson() 
        {
            return JsonConvert.SerializeObject(this); 
        }
    }
}