using AutoMapper;
using FurEverHomes.Data;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace FurEverHomes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdoptersControllerV2 : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdoptionDbContext _context;

        public AdoptersControllerV2(IMapper mapper, AdoptionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var adopter = await _context.Adopters
                .Include(a => a.Applications)
                .ToListAsync();

            var adoptersDto = _mapper.Map<List<AdopterDto>>(adopter);
            return Ok(adoptersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdopterDto>> GetAdopter(int id)
        {

            var adopter = await _context.Adopters
                .Include(a => a.Applications)
               .FirstOrDefaultAsync(a => a.AdopterId == id);

            if (adopter == null)
            {
                return NotFound();
            }

            var adopterDto = _mapper.Map<AdopterDto>(adopter);
            return Ok(adopterDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdopter(AddAdopterRequestDto addAdopterRequestDto)
        {
            var adopter = _mapper.Map<Adopter>(addAdopterRequestDto);

            // Save adopter to the database
            _context.Adopters.Add(adopter);
            await _context.SaveChangesAsync();

            await _context.Entry(adopter).Collection(a => a.Applications).LoadAsync();

            var adopterDto = _mapper.Map<AdopterDto>(adopter);
            return CreatedAtAction(nameof(GetAdopter), new { id = adopterDto.AdopterId }, adopterDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdopter(int id, UpdateAdopterDto updateAdopterRequestDto)
        {
            var adopter = await _context.Adopters
                .Include(a => a.Applications)
                .FirstOrDefaultAsync(a => a.AdopterId == id);

            if (adopter == null)
            {
                return NotFound();
            }

            _mapper.Map(updateAdopterRequestDto, adopter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var adopterDto = _mapper.Map<AdopterDto>(adopter);
            return Ok(adopterDto);
        }

        private bool AdopterExists(int id)
        {
            return _context.Adopters.Any(a => a.AdopterId == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdopter(int id)
        {
            var adopter = await _context.Adopters
                .Include(a => a.Applications)
                .FirstOrDefaultAsync(a => a.AdopterId == id);

            if (adopter == null)
            {
                return NotFound();
            }

            _context.Adopters.Remove(adopter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}