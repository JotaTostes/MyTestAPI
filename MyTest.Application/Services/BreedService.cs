using MyTest.Application.DTOs;
using MyTest.Application.Entities;
using MyTest.Application.Interfaces;
using MyTest.Domain.Interfaces;
using MyTest.Infrastructure.HttpClients;
using Newtonsoft.Json;

namespace MyTest.Application.Services
{
    public class BreedService : IBreedService
    {
        private readonly DogApiClient _dogApiClient;
        private readonly IBreedRepository _breedRepository;

        public BreedService(DogApiClient dogApiClient, IBreedRepository breedRepository)
        {
            _dogApiClient = dogApiClient;
            _breedRepository = breedRepository;
        }

        public async Task<ApiResponse> GetAllBreedsAsync()
        {
            var response = await _dogApiClient.GetAsync("breeds");
            var teste = JsonConvert.DeserializeObject<ApiResponse>(response);
            return JsonConvert.DeserializeObject<ApiResponse>(response);
        }

        public async Task<ApiResponse> GetBreedByIdAsync(string id)
        {
            var json = await _dogApiClient.GetAsync($"breeds/{id}");
            var breedResponse = JsonConvert.DeserializeObject<ApiResponse>(json);

            return breedResponse;
        }

        public async Task AddBreedAsync(Breeds breed)
        {
            await _breedRepository.AddBreedAsync(breed);
        }

        public async Task UpdateBreedAsync(Breeds breed)
        {
            await _breedRepository.UpdateBreedAsync(breed);
        }

        public async Task DeleteBreedAsync(Guid id)
        {
            await _breedRepository.DeleteBreedAsync(id);
        }
    }
}
