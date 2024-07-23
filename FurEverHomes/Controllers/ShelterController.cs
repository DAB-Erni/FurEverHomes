using AutoMapper;
using FurEverHomes.Data;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurEverHomes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdoptionDbContext _context;

        public ShelterController(IMapper mapper, AdoptionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shelters = await _context.Shelters
                .Include(s => s.Pets)
                .Include(s => s.Applications)
                .ToListAsync();

            var shelterDtos = _mapper.Map<List<ShelterDto>>(shelters);
            return Ok(shelterDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShelterDto>> GetShelter(int id)
        {
            var shelter = await _context.Shelters
                .Include(s => s.Pets)
                .Include(s => s.Applications)
                .FirstOrDefaultAsync(s => s.ShelterId == id);

            if (shelter == null)
            {
                return NotFound();
            }

            var shelterDto = _mapper.Map<ShelterDto>(shelter);
            return Ok(shelterDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddShelter(AddShelterRequestDto addShelterRequestDto)
        {
            var shelter = _mapper.Map<Shelter>(addShelterRequestDto);

            // Save shelter to the database
            _context.Shelters.Add(shelter);
            await _context.SaveChangesAsync();

            var shelterDto = _mapper.Map<ShelterDto>(shelter);
            return CreatedAtAction(nameof(GetShelter), new { id = shelterDto.ShelterId }, shelterDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelter(int id, UpdateShelterDto updateShelterDto)
        {
            var shelter = await _context.Shelters
                .Include(s => s.Pets)
                .Include(s => s.Applications)
                .FirstOrDefaultAsync(s => s.ShelterId == id);

            if (shelter == null)
            {
                return NotFound();
            }

            _mapper.Map(updateShelterDto, shelter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var shelterDto = _mapper.Map<ShelterDto>(shelter);
            return Ok(shelterDto);
        }

        private bool ShelterExists(int id)
        {
            return _context.Shelters.Any(s => s.ShelterId == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelter(int id)
        {
            var shelter = await _context.Shelters
                .Include(s => s.Pets)
                .Include(s => s.Applications)
                .FirstOrDefaultAsync(s => s.ShelterId == id);

            if (shelter == null)
            {
                return NotFound();
            }

            _context.Shelters.Remove(shelter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}