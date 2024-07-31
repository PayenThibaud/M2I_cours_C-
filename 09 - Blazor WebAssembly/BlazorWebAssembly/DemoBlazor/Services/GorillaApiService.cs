using DemoBlazor.Models;
using System.Net.Http.Json;

namespace DemoBlazor.Services
{
    public class GorillaApiService : IGorillaService
    {
        private readonly HttpClient _httpClient;
        private const string _baseApiRoute = "https://jsonplaceholder.typicode.com/posts";

        public GorillaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync(_baseApiRoute + $"/{id}");
            // DELETE http://localhost:XXX/api/gorilla/1
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Post(Gorilla gorilla)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRoute, gorilla);
            // POST http://localhost:XXX/api/gorilla
            // le gorilla se retrouve dans le body
            return result.IsSuccessStatusCode;
        }
    }
}
