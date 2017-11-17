using System;
using System.Collections.Generic;

namespace WeatherAPI.Data
{
    public class Stations: EndPointBaseClass
    {
        
        public Stations()
		{
            this.EndPoint = "https://www.ncdc.noaa.gov/cdo-web/api/v2/stations";
            this.Parameters = new Dictionary<string, Tuple<string, string, bool>>()
            {
                // bool value shows if the parameter is optional 

                {"datasetid", Tuple.Create(
                    "",
                    "Accepts a valid dataset id or a chain of dataset ids seperated by ampersands. Stations returned will be supported by dataset(s) specified",
                    true
                )},
                {"locationid", Tuple.Create(
                    "",
                    "Accepts a valid location id or a chain of location ids seperated by ampersands. Stations returned will contain data for the location(s) specified",
                    true
                )},
                {"datacategoryid", Tuple.Create(
                    "",
                    "Accepts a valid data category id or an array of data category ids. Stations returned will be associated with the data category(ies) specified",
                    true
                )},
                {"datatypeid", Tuple.Create(
                    "",
                    "Accepts a valid data type id or a chain of data type ids seperated by ampersands. Stations returned will contain all of the data type(s) specified",
                    true
                )},
                {"startdate", Tuple.Create(
                    "",
                    "Accepts valid ISO formated date (yyyy-mm-dd). Stations returned will have data after the specified date. Paramater can be use independently of enddate",
                    true
                )},
                {"enddate", Tuple.Create(
                    "",
                    "Accepts valid ISO formated date (yyyy-mm-dd). Stations returned will have data before the specified date. Paramater can be use independently of startdate",
                    true
                )},
                {"sortfield", Tuple.Create(
                    "",
                    "The field to sort results by. Supports id, name, mindate, maxdate, and datacoverage fields",
                    true
                )},
                {"sortorder", Tuple.Create(
                    "",
                    "Which order to sort by, asc or desc. Defaults to asc",
                    true
                )},
                {"limit", Tuple.Create(
                    "100",
                    "Defaults to 100, limits the number of results in the response. Maximum is 1000",
                    true
                )},
                {"offset", Tuple.Create(
                    "0",
                    "Defaults to 0, used to offset the resultlist. The example would begin with record 24",
                    true
                )}
            };
		}

        //private readonly string DataSets = "https://www.ncdc.noaa.gov/cdo-web/api/v2/datasets";

        //private readonly string DataCategories = "https://www.ncdc.noaa.gov/cdo-web/api/v2/datacategories";

        //private readonly string DataTypes = "https://www.ncdc.noaa.gov/cdo-web/api/v2/datatypes";

        //private readonly string LocationCategories = "https://www.ncdc.noaa.gov/cdo-web/api/v2/locationcategories";

        //private readonly string Locations = "https://www.ncdc.noaa.gov/cdo-web/api/v2/locations";

        //private readonly string Data = "https://www.ncdc.noaa.gov/cdo-web/api/v2/data";

        //public string GetStationsEP (Dictionary<string, string> parameters)
        //{
            
        //}

    }
}
