using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace WeatherAPI.DataResponse
{
    public abstract class ResponseBaseClass
    {
        public Metadata metadata { get; set; }
    }
}