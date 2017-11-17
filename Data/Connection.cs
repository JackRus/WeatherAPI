using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherAPI.Data
{
    public class ConnectNOAA
    {
        public string Data { get; set; }
        private readonly string Token = "YmGfnzXmuLVrtJtGWICQQxfKMxbOdMAF";

        public string Request(string url, Dictionary<string, string> headers = null)
        {
            SendRequest(url, headers).Wait();
            return this.Data;
        }

        async Task SendRequest(string url, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                // default header for authorization
                client.DefaultRequestHeaders.Add("token", this.Token);

                // add all headers provided by user
                if (headers != null && headers.Count > 0)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                // send request
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode(); // Throw if not success
                        using(HttpContent tempContent = response.Content)
                        {
                            this.Data = await tempContent.ReadAsStringAsync();
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    this.Data = ($"Request exception: {e.Message}");
                }
            }
        }
    }
}

