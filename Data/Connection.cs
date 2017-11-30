using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using WeatherAPI.Data;

namespace WeatherAPI.Data
{
    public class ConnectNOAA
    {
        public string Data { get; set; }
        // makes open sockets reusable
        private HttpClient client = new HttpClient();
        
        public string Request(string url)
        {
            SendRequest(url).Wait();
            return this.Data;
        }

        async Task SendRequest(string url)
        {
            // default header for authorization
            client.DefaultRequestHeaders.Add("token", Token.Key);
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
                this.Data = $"Request exception: {e.Message}";
            }
        }
    }
}

