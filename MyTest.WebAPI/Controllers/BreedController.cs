using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTest.Application.Entities;
using MyTest.Application.Interfaces;

namespace MyTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBreeds()
        {
            var breeds = await _breedService.GetAllBreedsAsync();
            return Ok(breeds);
        }

        [HttpGet("from-database")]
        public async Task<IActionResult> GetAllBreedsFromDatabase()
        {
            var breeds = await _breedService.GetAllFromDataBase();
            return Ok(breeds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreedById(string id)
        {
            var breed = await _breedService.GetBreedByIdAsync(id);
            return Ok(breed);
        }

        [HttpPost]
        public async Task<ActionResult> AddBreed([FromBody] Breeds breed)
        {
            await _breedService.AddBreedAsync(breed);
            return CreatedAtAction(nameof(GetBreedById), new { id = breed.Id }, breed);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBreed(Guid id, [FromBody] Breeds breed)
        {
            if (id != breed.Id)
            {
                return BadRequest();
            }

            await _breedService.UpdateBreedAsync(breed);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBreed(Guid id)
        {
            await _breedService.DeleteBreedAsync(id);
            return NoContent();
        }
    }
}
