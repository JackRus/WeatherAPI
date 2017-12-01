using System;
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
                jsonData = parameters.prepareData(connect); 
            }

            //objectData.PrintToConsole();
            return jsonData;
        }
    }
}
