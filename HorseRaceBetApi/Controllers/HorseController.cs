using HorseRaceBetApi.Entities;
using HorseRaceBetApi.Servicies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly HorseService _horseService;

        public HorseController(HorseService horseService)
        {
            _horseService = horseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Horse>>> GetAll()
        {
            return Ok(await _horseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Horse>>> GetById(int id)
        {
            var horse = await _horseService.GetByIdAsync(id);
            if (horse == null)
            {
                return NotFound();
            }
            return Ok(horse);
        }

        //[HttpGet("{id}/Betters")]
        //public async Task<IActionResult> GetBettersByIdAsyncint(int id)
        //{
        //    return Ok(await _horseService.GetAllBettersByIdAsync(id));
        //}

        [HttpPost]
        public async Task<IActionResult> Add(Horse horse)
        {
            return Ok(await _horseService.AddAsync(horse));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHorse(Horse horse)
        {
            await _horseService.UpdateHorseAsync(horse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _horseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
