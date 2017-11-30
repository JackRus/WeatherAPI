namespace WeatherAPI.DataResponse
{
	public class Metadata
	{
		public Metadata()
		{
			this.resultset = new ResultSet();
		}
		public ResultSet resultset { get; set; }
	}
}