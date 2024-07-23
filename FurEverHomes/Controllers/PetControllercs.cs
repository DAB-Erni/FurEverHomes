//using AutoMapper;
//using FurEverHomes.Data;
//using FurEverHomes.Models;
//using FurEverHomes.Models.Domain;
//using FurEverHomes.Models.DTO;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FurEverHomes.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class PetsController : ControllerBase
//    {
//        private readonly IMapper _mapper;
//        private readonly AdoptionDbContext _context;

//        public PetsController(IMapper mapper, AdoptionDbContext context)
//        {
//            _mapper = mapper;
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var pets = _context.Pets.ToList();
//            var petDto = _mapper.Map<List<Pet>>(pets);
//            return Ok(petDto);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<PetDto> GetPet(int id)
//        {
//            var pet = _context.Pets.Find(id);

//            return Ok(pet);
//        }

//        [HttpPost]
//        public IActionResult AddPet(AddPetRequestDto addPetRequestDto)
//        {
//            var pet = _mapper.Map<Pet>(addPetRequestDto);

//            // Save adopter to the database
//            _context.Pets.Add(pet);
//            _context.SaveChanges();

//            return Ok(pet);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdatePet(int id, UpdatePetDto updatePetDto)
//        {
//            var pet = _context.Pets.Find(id);
//            if (pet == null)
//            {
//                return NotFound();
//            }
//            _mapper.Map(updatePetDto, pet);
//            _context.Entry(pet).State = EntityState.Modified;
//            _context.SaveChanges();

//            return Ok(pet);
//        }


//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePet(int id)
//        {
//            var pet = await _context.Pets.FindAsync(id);

//            if (pet == null)
//            {
//                return NotFound();
//            }

//            // Remove the pet from the database
//            _context.Pets.Remove(pet);
//            await _context.SaveChangesAsync();

//            return Ok(pet);
//        }
//    }
//}


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
    public class PetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdoptionDbContext _context;

        public PetsController(IMapper mapper, AdoptionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _context.Pets
                .Include(p => p.Applications)
                .Include(p => p.Shelter)
                .ToListAsync();

            var petsDto = _mapper.Map<List<PetDto>>(pets);
            return Ok(petsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDto>> GetPet(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Applications)
                .Include(p => p.Shelter)
                .FirstOrDefaultAsync(p => p.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }

            var petDto = _mapper.Map<PetDto>(pet);
            return Ok(petDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(AddPetRequestDto addPetRequestDto)
        {
            var pet = _mapper.Map<Pet>(addPetRequestDto);

            // Save pet to the database
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            await _context.Entry(pet).Collection(p => p.Applications).LoadAsync();
            await _context.Entry(pet).Reference(p => p.Shelter).LoadAsync();

            var petDto = _mapper.Map<PetDto>(pet);
            return CreatedAtAction(nameof(GetPet), new { id = petDto.PetId }, petDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, UpdatePetDto updatePetRequestDto)
        {
            var pet = await _context.Pets
                .Include(p => p.Applications)
                .Include(p => p.Shelter)
                .FirstOrDefaultAsync(p => p.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }

            _mapper.Map(updatePetRequestDto, pet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var petDto = _mapper.Map<PetDto>(pet);
            return Ok(petDto);
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(p => p.PetId == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Applications)
                .Include(p => p.Shelter)
                .FirstOrDefaultAsync(p => p.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}