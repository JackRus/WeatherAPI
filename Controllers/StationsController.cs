using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Data;
using WeatherAPI.DataResponse;
using static System.Console;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        
        // GET api/stations/params
        [HttpGet]
        public string Get(StationsParameters parameters, string stationid = null)
        {
            var connect = new ConnectNOAA();
            var jsonData = "";
            if (!String.IsNullOrEmpty(stationid))
            {   
                jsonData = connect.Request($"{new StationsParameters().EndPoint}/{stationid}");
            }
            else
            {
                // if required parameters are missing - return error message
                if (parameters.checkRequired().Item1){
                    return parameters.checkRequired().Item2;
                }

                int limit;
                Int32.TryParse(parameters.Limit, out limit);

                if (limit > DefaultValues.MaxLimit) 
                {
                    var container = new StationsResponse();
                    var tempContainer = new StationsResponse();
                    do {
                        // max limit per NOAA API
                        parameters.Limit = DefaultValues.MaxLimit.ToString();
                        string tempData = connect.Request(parameters.BuildUrl());

                        Write(tempData);

                        // for each partial request
                        tempContainer = JsonConvert.DeserializeObject<StationsResponse>(tempData);
                        
                        // update total count
                        container.metadata.resultset.count += tempContainer.results.Count;

                        // add all records
                        container.results.AddRange(tempContainer.results); 

                        // update offset, step 1000.
                        parameters.OffSet += DefaultValues.MaxLimit;
                        limit -= DefaultValues.MaxLimit;
                    } while (limit > 0);

                    // convert to json
                    jsonData = JsonConvert.SerializeObject(container);
                }
                else {
                    jsonData = connect.Request(parameters.BuildUrl());
                }
             }
            
            //objectData.PrintToConsole();
            return jsonData;
        }
    }
}
