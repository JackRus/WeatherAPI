using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace WeatherAPI.DataResponse
{
    public class StationsResponse: ResponseBaseClass
    {
        public StationsResponse ()
        {
            this.metadata = new Metadata();
            this.results = new List<Station>();
        }

        public List<Station> results { get; set; }
    }
}


// public void PrintToConsole()
        // {
        //     int count = 0;
        //     this.results.ForEach( item => {
        //         count ++;
        //         WriteLine($"Item {count}");
        //         item.GetType().GetProperties().ToList().ForEach(property =>
        //         {
        //             WriteLine($"{property.Name} = {property.GetValue(item)}");
        //         });
        //         WriteLine();
        //     });
        // }