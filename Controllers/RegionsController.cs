using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController(IRegionRepository regionRepository, IMapper mapper) : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAll();
            var regionDTO = mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionDTO);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Reader")]
        public async Task<ActionResult<Region>> GetById(int id)
        {
            var region = await regionRepository.GetById(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        [HttpPut]
        [Authorize(Roles = "writer")]
        public async Task<ActionResult> UpdateRegion([FromBody] RegionDTO region)
        {
            var foundRegion = await regionRepository.GetById(region.Id);

            if (foundRegion == null)
            {
                return NotFound();
            }

            foundRegion.Name = region.Name;

            await regionRepository.UpdateRegion(foundRegion);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<ActionResult> AddRegion([FromBody] RegionDTO addRegionDTO)
        {
            var newRegion = await regionRepository.AddRegion(addRegionDTO);
            return CreatedAtAction(nameof(GetById), new { id = newRegion.Id }, newRegion);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<ActionResult> DeleteRegion(int id)
        {
            var region = await regionRepository.GetById(id);

            if (region == null)
            {
                return NotFound();
            }

            await regionRepository.DeleteRegion(id);
            return Ok();
        }
    }
}
