using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestAzureAPIIntegrationTest
{
    public class Class1
    {
        private string urlBase = @"https://quisitivetestazureapi.azurewebsites.net/";

        [Fact]
        public async Task Get_Test()
        {
            var url = $"{urlBase}api/values";
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            //var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}
