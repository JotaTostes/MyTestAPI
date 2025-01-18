using MyTest.Application.DTOs;
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
        Task<ApiResponse> GetAllBreedsAsync();
        Task<ApiResponse> GetBreedByIdAsync(string id);
        Task AddBreedAsync(Breeds breed);
        Task UpdateBreedAsync(Breeds breed);
        Task DeleteBreedAsync(Guid id);
    }
}
