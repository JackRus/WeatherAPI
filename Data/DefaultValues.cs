namespace WeatherAPI.Data
{
    public static class DefaultValues
    {
        public static readonly int MaxLimit = 1000;
        public static readonly int Limit = 100;
        //Supports id, name, mindate, maxdate, and datacoverage fields.
        public static readonly string SortField = "name";
        public static readonly string SortOrder = "asc";
        public static readonly string Meta = "yes";
        public static readonly int LocalMaxLimit = 10000;
    }
}