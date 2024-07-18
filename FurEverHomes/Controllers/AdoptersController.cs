using FurEverHomes.Data;
using FurEverHomes.Models;
using FurEverHomes.Models.Domain;
using FurEverHomes.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurEverHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptersController : ControllerBase
    {
        private readonly AdoptionDbContext dbContext;

        public AdoptersController(AdoptionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET ALL ADOPTERS
        // GET: https://localhost:portnumber/api/adopters
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data from database - domain models
            var adopters = dbContext.Adopters.ToList();

            // Map domain models to DTOs
            var adopterDto = new List<AdoptersDto>();
            foreach (var adopter in adopters)
            {
                adopterDto.Add(new AdoptersDto()
                {
                    Id = adopter.Id,
                    FirstName = adopter.FirstName,
                    LastName = adopter.LastName,
                    Email = adopter.Email,
                    Phone = adopter.Phone,
                    Address = adopter.Address,
                });
            }
            // Return DTOs
            return Ok(adopterDto);
        }

        // GET SINGLE ADOPTER (By Id)
        // GET: https://localhost:portnumber/api/adopters/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Get adopter domain model from database
            var adopter = dbContext.Adopters.Find(id);
            // var adopter = dbContext.Adopters.FirstOrDefault(x => x.Id == id);

            if (adopter == null)
            {
                return NotFound();
            }

            // Map/Convert Adopter domain model to adopter DTO

            var adopterDto = new AdoptersDto
            {
                Id = adopter.Id,
                FirstName = adopter.FirstName,
                LastName = adopter.LastName,
                Email = adopter.Email,
                Phone = adopter.Phone,
                Address = adopter.Address,
            };

            // Return DTO back to client
            return Ok(adopterDto);
        }

        // POST to create new adopter
        // POST: https:localhost:portnumber/api/adopters
        [HttpPost]
        public IActionResult Create([FromBody] AddAdopterRequestDto addAdopterRequestDto)
        {
            // Map or convert DTO to domain model
            var adopterDomainModel = new Adopters
            {
                FirstName = addAdopterRequestDto.FirstName,
                LastName = addAdopterRequestDto.LastName,
                Email = addAdopterRequestDto.Email,
                Phone = addAdopterRequestDto.Phone,
                Address = addAdopterRequestDto.Address,
            };

            // Use domain model to create region
            dbContext.Adopters.Add(adopterDomainModel);
            dbContext.SaveChanges();

            // Map domain model back to DTO
            var adopterDto = new AdoptersDto
            {
                Id = adopterDomainModel.Id,
                FirstName = adopterDomainModel.FirstName,
                LastName = adopterDomainModel.LastName,
                Email = adopterDomainModel.Email,
                Phone = adopterDomainModel.Phone,
                Address = adopterDomainModel.Address,
            };

            return CreatedAtAction(nameof(GetById), new { id = adopterDomainModel.Id }, adopterDomainModel);
        }

        // PUT
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateAdopterDto updateAdopterDto)
        {
            var adopter = dbContext.Adopters.Find(id);
            if (adopter == null)
            {
                return NotFound();
            }

            adopter.FirstName = updateAdopterDto.FirstName;
            adopter.LastName = updateAdopterDto.LastName;
            adopter.Email = updateAdopterDto.Email;
            adopter.Phone = updateAdopterDto.Phone;
            adopter.Address = updateAdopterDto.Address;

            dbContext.SaveChanges();

            return Ok(adopter);
        }

        // DELETE
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var adopter = dbContext.Adopters.Find(id);

            if(adopter == null)
            {
                return NotFound();
            }

            dbContext.Adopters.Remove(adopter);
            dbContext.SaveChanges();

            return Ok(adopter);
        }
    }
}
