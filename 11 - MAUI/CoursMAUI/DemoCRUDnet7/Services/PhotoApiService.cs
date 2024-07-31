using DemoCRUDnet7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDnet7.Services
{
    public class PhotoApiService : ICRUDService<Photo>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiRoute = "https://jsonplaceholder.typicode.com/photos";

        public PhotoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync(_baseApiRoute + $"/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<Photo?> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Photo>(_baseApiRoute + $"/{id}");
            return result;
        }

        public async Task<List<Photo>> GetAll()
        {
            var result = (await _httpClient.GetFromJsonAsync<List<Photo>>(_baseApiRoute)).Take(40).ToList();
            return result!;
        }

        public async Task<bool> Post(Photo photo)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseApiRoute, photo);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Put(Photo photo)
        {
            var result = await _httpClient.PutAsJsonAsync(_baseApiRoute + $"/{photo.Id}", photo);
            return result.IsSuccessStatusCode;
        }
    }
}
