using MyTest.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Domain.Interfaces
{
    public interface IBreedRepository
    {
        Task<Breed> GetBreedByIdAsync(Guid id);
        Task<IEnumerable<Breed>> GetAllBreedsAsync();
        Task AddBreedAsync(Breed breed);
        Task UpdateBreedAsync(Breed breed);
        Task DeleteBreedAsync(Guid id);
    }
}
