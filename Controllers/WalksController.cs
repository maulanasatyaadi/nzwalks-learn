using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.CustomActionFilter;
using NZWalks.Models.DTO;
using NZWalks.Repositories;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController(IWalkingPathRepository walkingPathRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? orderBy, [FromQuery] bool? isAscending)
        {
            var walkingList = await walkingPathRepository.GetAll(filterOn, filterQuery, orderBy, isAscending ?? true);
            return Ok(mapper.Map<List<WalkingPathDTO>>(walkingList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var walkingPath = await walkingPathRepository.GetById(id);

            if (walkingPath == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkingPathDTO>(walkingPath));
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkingPath(AddWalkingPathDTO walkingPath)
        {
            var newWalkingPath = await walkingPathRepository.AddWalkingPath(walkingPath);
            return CreatedAtAction(nameof(GetById), new { id = newWalkingPath.Id }, newWalkingPath);
        }

        [HttpPut("{id:int}")]
        [ValidationModel]
        public async Task<IActionResult> UpdateWalkingPath(int id, UpdateWalkingPathDTO walkingPath)
        {
            await walkingPathRepository.UpdateWalkingPath(id, walkingPath);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalkingPath(int id)
        {
            await walkingPathRepository.DeleteWalkingPath(id);
            return NoContent();
        }
    }
}
