using Microsoft.EntityFrameworkCore;
using MyTest.Application.Entities;
using MyTest.Domain.Interfaces;
using MyTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Infrastructure.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly DogDbContext _context;

        public BreedRepository(DogDbContext context)
        {
            _context = context;
        }

        public async Task<Breeds> GetBreedByIdAsync(Guid id)
        {
            return await _context.Breeds
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Breeds>> GetAllBreedsAsync()
        {
            return await _context.Breeds
                .ToListAsync();
        }

        public async Task AddBreedAsync(Breeds breed)
        {
            await _context.Breeds.AddAsync(breed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBreedAsync(Breeds breed)
        {
            _context.Breeds.Update(breed);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBreedAsync(Guid id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed != null)
            {
                _context.Breeds.Remove(breed);
                await _context.SaveChangesAsync();
            }
        }
    }
}
