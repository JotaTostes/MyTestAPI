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
        Task<Breeds> GetBreedByIdAsync(Guid id);
        Task<IEnumerable<Breeds>> GetAllBreedsAsync();
        Task AddBreedAsync(Breeds breed);
        Task UpdateBreedAsync(Breeds breed);
        Task DeleteBreedAsync(Guid id);
    }
}
