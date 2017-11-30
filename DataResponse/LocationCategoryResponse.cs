using System.Collections.Generic;

namespace WeatherAPI.DataResponse
{
    public class LocationCategoryResponse: ResponseBaseClass
    {
        public List<LocationCategory> results { get; set; }
    }
}