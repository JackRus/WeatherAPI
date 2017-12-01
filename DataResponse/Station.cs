using Newtonsoft.Json;

namespace WeatherAPI.DataResponse
{
    public class Station
    {
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string elevation { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string mindate { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string maxdate { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string latitude { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string name { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string datacoverage { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string id { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string elevationUnit { get; set; }
		
		[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
		public string longitude { get; set; }
    }
}