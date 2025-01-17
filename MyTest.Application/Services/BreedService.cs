using MyTest.Application.DTOs;
using MyTest.Application.Entities;
using MyTest.Application.Interfaces;
using MyTest.Domain.Interfaces;
using MyTest.Infrastructure.HttpClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PaginatedResponse<Breed>> GetAllBreedsAsync()
        {
            var response = await _dogApiClient.GetAsync("breeds");
            return JsonConvert.DeserializeObject<PaginatedResponse<Breed>>(response);
        }

        public async Task<Breed> GetBreedByIdAsync(string id)
        {
            var json = await _dogApiClient.GetAsync($"breeds/{id}");
            var breedResponse = JsonConvert.DeserializeObject<BreedResponse>(json);

            return breedResponse.Data;
        }

        public async Task AddBreedAsync(Breed breed)
        {
            await _breedRepository.AddBreedAsync(breed);
        }

        public async Task UpdateBreedAsync(Breed breed)
        {
            await _breedRepository.UpdateBreedAsync(breed);
        }

        public async Task DeleteBreedAsync(Guid id)
        {
            await _breedRepository.DeleteBreedAsync(id);
        }
    }
}
