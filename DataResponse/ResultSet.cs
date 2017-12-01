namespace WeatherAPI.DataResponse
{
	public class ResultSet
	{
		public ResultSet()
		{
			this.offset = 1;
		}
		public int offset { get; set; }
		public int count { get; set; }
		public int limit { get; set; }
	}
}