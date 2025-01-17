using Hangfire;
using MyTest.Application.Interfaces;
using MyTest.Application.Entities;
using System;
using System.Threading.Tasks;

namespace MyTest.Jobs
{
    public class BreedUpsertJob
    {
        private readonly IBreedService _breedService;

        public BreedUpsertJob(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public async Task ExecuteAsync()
        {
            var breeds = await _breedService.GetAllBreedsAsync();
            foreach (var breed in breeds.Data)
            {
                await _breedService.UpdateBreedAsync(breed);
            }
        }
    }
}
