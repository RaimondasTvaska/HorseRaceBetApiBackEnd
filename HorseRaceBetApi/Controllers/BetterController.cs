using HorseRaceBetApi.Entities;
using HorseRaceBetApi.Servicies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BetterController : ControllerBase
    {
        private readonly BetterService _betterService;

        public BetterController(BetterService betterService)
        {
            _betterService = betterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Better>>> GetAll()
        {
            return Ok(await _betterService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Better>>> GetById(int id)
        {
            var better = await _betterService.GetByIdAsync(id);
            if (better == null)
            {
                return NotFound();
            }
            return Ok(better);
        }

        [HttpGet("FilterByHorseId/{horseId}")]
        public async Task<IActionResult> GetBettersByHorseIdAsync(int horseId)
        {
            return Ok(await _betterService.GetBettersByHorseIdAsync(horseId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Better better)
        {
            return Ok(await _betterService.AddAsync(better));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBetter(Better better)
        {
            await _betterService.UpdateBetterAsync(better);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _betterService.DeleteAsync(id);
            return NoContent();
        }
    }
}
