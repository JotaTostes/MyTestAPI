using MyTest.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Application.Interfaces
{
    public interface IBreedService
    {
        Task<PaginatedResponse<Breed>> GetAllBreedsAsync();
        Task<Breed> GetBreedByIdAsync(string id);
        Task AddBreedAsync(Breed breed);
        Task UpdateBreedAsync(Breed breed);
        Task DeleteBreedAsync(Guid id);
    }
}
