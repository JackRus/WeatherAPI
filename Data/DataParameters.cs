using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System;
using WeatherAPI.DataResponse;

namespace WeatherAPI.Data
{
    public class DataParameters: ParametersBaseClass
    {
        public DataParameters()
        {
            this.EndPoint = this.EndPointBase + "data";
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
            
            if (Limit <=0)
            { 
                Limit = DefaultValues.Limit; 
            }
            checkValue("limit", Limit.ToString());

            checkValue("offset", OffSet.ToString());
            checkValue("sortfield", SortBy);
            checkValue("sortorder", Order);
            return this.Url;
        }

        public (bool, string) checkRequired () 
        {
            string response = "";
            bool status = false;
            if (String.IsNullOrEmpty(this.DatasetId)){
                response += "Parameter 'DatasetID' is required.";
                status = true;
            }
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

        public override string prepareData (ConnectNOAA connect) 
        {
            int amountRequested = this.Limit;

            if (amountRequested > DefaultValues.MaxLimit) 
            {
                var container = new StationsResponse();
                var tempContainer = new StationsResponse();

                do {
                    // max limit per NOAA API
                    this.Limit = DefaultValues.MaxLimit;
                    
                    // get 1000 records from DB
                    string tempData = connect.Request(this.BuildUrl());

                    // convert to object
                    tempContainer = JsonConvert.DeserializeObject<StationsResponse>(tempData);
                    
                    // update # of records
                    container.metadata.resultset.count += tempContainer.results.Count;
                    
                    // add all records from this request to main container
                    container.results.AddRange(tempContainer.results); 

                    // update offset, step 1000.
                    this.OffSet += DefaultValues.MaxLimit;
                    amountRequested -= DefaultValues.MaxLimit;

                } while (amountRequested > 0);

                // update total # of records found in NOAA db
                container.metadata.resultset.offset = this.OffSet;

                // convert to json
                return JsonConvert.SerializeObject(container);
            }
            else 
            {
                // convert to JSON
                return connect.Request(this.BuildUrl());
            }
        }
    }
}