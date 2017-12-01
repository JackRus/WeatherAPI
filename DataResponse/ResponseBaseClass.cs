using System.Collections.Generic;
using System.Linq;
using WeatherAPI.Data;
using static System.Console;

namespace WeatherAPI.DataResponse
{
    public abstract class ResponseBaseClass
    {
        public Metadata metadata { get; set; }
        public abstract void excludeFields(string indexString);

        public void copyOffset (int offset)
        {
            this.metadata.resultset.offset = offset == 0 ? 1 : offset;
        }

        public void copyLimit (int limit)
        {
            this.metadata.resultset.limit = limit;
        }

        public void updateCount (int count)
        {
            // update # of records
            this.metadata.resultset.count += count;
        } 

    }
}