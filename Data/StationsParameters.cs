using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace WeatherAPI.Data
{
    public class StationsParameters: ParametersBaseClass
    {
        public StationsParameters()
        {
            this.EndPoint = this.EndPointBase + "stations";
        }
        
        public string Metadata { get; set; }
        public string DatasetId { get; set; }
        public string LocationId { get; set; }
        public string DatacategoryId { get; set; }
        public string DatatypeId { get; set; } 
        
        public override string BuildUrl()
        {
            this.Url = this.EndPoint;
            // build URL string
            checkValue("datasetid", DatasetId);
            checkValue("datacategoryid", DatacategoryId);
            checkValue("locationid", LocationId);
            checkValue("datatypeid", DatatypeId);
            checkValue("startdate", From);
            checkValue("enddate", To);
            
            if (String.IsNullOrEmpty(Limit))
            { 
                Limit = DefaultValues.Limit.ToString(); 
            }
            checkValue("limit", Limit);

            checkValue("offset", OffSet);
            checkValue("sortfield", SortBy);
            checkValue("sortorder", Order);
            return this.Url;
        }



        public (bool, string) checkRequired () {
            string response = "";
            bool status = false;
            // if (String.IsNullOrEmpty(this.DatasetId)){
            //     response += "Parameter 'DatasetID' is required.";
            //     status = true;
            // }
            if (String.IsNullOrEmpty(this.From)){
                response += " Parameter 'From' is required.";
                status = true;
            }
            if (String.IsNullOrEmpty(this.To)){
                response += " Parameter 'To' is required.";
                status = true;
            }

            return (status, response);
        }
    }
}