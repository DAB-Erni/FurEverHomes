using AutoMapper;
using FurEverHomes.Data;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetAll()
        {
            var adopters = _context.Adopters.ToList();
            var adopterDto = _mapper.Map<List<Adopters>>(adopters);
            return Ok(adopterDto);
        }

        [HttpGet("{id}")]
        public ActionResult<AdopterDto> GetAdopter(int id)
        {
            // Retrieve adopter from the database
            var adopter = _context.Adopters.Find(id);

            return Ok(adopter);
        }

        [HttpPost]
        public IActionResult AddAdopter(AddAdopterRequestDto addAdopterRequestDto)
        {
            var adopter = _mapper.Map<Adopters>(addAdopterRequestDto);

            // Save adopter to the database
            _context.Adopters.Add(adopter);
            _context.SaveChanges();

            return Ok(adopter);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdopter(int id, UpdateAdopterDto updateAdopterDto)
        {
            // var adopter = _mapper.Map<AdoptersDto>(updateAdopterDto);
            // Update adopter in the database
            var adopter = _context.Adopters.Find(id);
            if (adopter == null)
            {
                return NotFound();
            }
            _mapper.Map(updateAdopterDto, adopter);
            _context.Entry(adopter).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(adopter);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdopter(int id)
        {
            // Delete adopter from the database
            var adopter = _context.Adopters.Find(id);
            if (adopter == null)
            {
                return NotFound();
            }

            // Remove the adopter from the database
            _context.Adopters.Remove(adopter);
            _context.SaveChanges();

            return Ok(adopter);
        }

    }
}