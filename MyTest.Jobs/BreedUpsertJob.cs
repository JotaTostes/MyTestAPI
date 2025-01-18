using Hangfire;
using MyTest.Application.Interfaces;
using MyTest.Application.Entities;
using System;
using System.Threading.Tasks;
using MyTest.Domain.Interfaces;

namespace MyTest.Jobs
{
    public class BreedUpsertJob
    {
        private readonly IBreedService _breedService;
        private readonly IBreedRepository _breedRepository;

        public BreedUpsertJob(IBreedService breedService,IBreedRepository breedRepository)
        {
            _breedService = breedService;
            _breedRepository = breedRepository;
        }

        public async Task ExecuteAsync()
        {
            var breeds = await _breedService.GetAllBreedsAsync();
            foreach (var breed in breeds.Data)
            {
                Breeds breedEntity = new Breeds
                {
                    Id = Guid.NewGuid(),
                    Name = breed.Attributes.Name,
                    Description = breed.Attributes.Description,
                    Hypoallergenic = breed.Attributes.Hypoallergenic,
                    FemaleWeightMin = breed.Attributes.Female_Weight.Min,
                    FemaleWeightMax = breed.Attributes.Female_Weight.Max,
                    MaleWeightMin = breed.Attributes.Male_Weight.Min,
                    MaleWeightMax = breed.Attributes.Male_Weight.Max,
                    LifeMin = breed.Attributes.Life.Min,
                    LifeMax = breed.Attributes.Life.Max
                };
                await _breedRepository.AddBreedAsync(breedEntity);
            };
        }
    }
}
