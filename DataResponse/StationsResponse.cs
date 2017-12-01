using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public override void excludeFields(string indexString) 
        {
            // null check
            if (indexString == null) return;

            // TODO TryParse
            List<string> indexes = indexString.Split('-').ToList();

            this.results.ForEach ( x => { 
                if (indexes.Contains("1")) x.elevation = null;
                if (indexes.Contains("2")) x.mindate = null;
                if (indexes.Contains("3")) x.maxdate = null;
                if (indexes.Contains("4")) x.latitude = null;
                if (indexes.Contains("5")) x.name = null;
                if (indexes.Contains("6")) x.datacoverage = null;
                if (indexes.Contains("7")) x.id = null;
                if (indexes.Contains("8")) x.elevationUnit = null;            
                if (indexes.Contains("9")) x.longitude = null;
            });
        }
    }
}