using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Infrastructure.HttpClients
{
    public class DogApiClient
    {
        private readonly HttpClient _httpClient;

        public DogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string endpoint)
        {
            string baseUrl = "https://dogapi.dog/api/v2";

            string url = $"{baseUrl}/{endpoint}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
