using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System;
using WeatherAPI.DataResponse;

namespace WeatherAPI.Data
{
    public class StationsParameters: ParametersBaseClass
    {
        public string DatasetId { get; set; }
        public string LocationId { get; set; }
        public string DatacategoryId { get; set; }
        public string DatatypeId { get; set; } 
        public string Exclude { get; set; }
        
        public StationsParameters()
        {
            this.EndPoint = this.EndPointBase + "stations";
        }
        
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
            
            if (Limit <= 0)
            { 
                Limit = DefaultValues.Limit; 
            }
            checkValue("limit", Limit.ToString());

            checkValue("offset", OffSet.ToString());
            checkValue("sortfield", SortBy);
            checkValue("sortorder", Order);
            return this.Url;
        }

        public override string prepareData (ConnectNOAA connect) 
        {
            // limits max records requested: 10,000 records
            int amountRequested = this.Limit > DefaultValues.LocalMaxLimit ? DefaultValues.LocalMaxLimit : this.Limit;
            
            int maxLimit = DefaultValues.MaxLimit;

            var container = new StationsResponse();
            var tempContainer = new StationsResponse();
            string tempData;
            // update total # of records found in NOAA db
            container.copyOffset(this.OffSet);
            container.copyLimit(this.Limit);

            do {
                // max limit per NOAA API
                this.Limit = (maxLimit < amountRequested) ? maxLimit : amountRequested;

                // get 1000 records from DB
                tempData = connect.Request(this.BuildUrl());

                // convert to object
                tempContainer = JsonConvert.DeserializeObject<StationsResponse>(tempData);

                container.updateCount(tempContainer.results.Count);
                
                // add all records from this request to main container
                container.results.AddRange(tempContainer.results); 

                // update offset, step 1000.
                this.OffSet += maxLimit;
                amountRequested -= maxLimit;

            } while (amountRequested > 0);

            container.excludeFields(this.Exclude);
            // convert to json
            return JsonConvert.SerializeObject(container);

        }
    }
}