//using AutoMapper;
//using FurEverHomes.Data;
//using FurEverHomes.Models.Domain;
//using FurEverHomes.Models.DTO;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;

//namespace FurEverHomes.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ApplicationsController : ControllerBase
//    {
//        private readonly IMapper _mapper;
//        private readonly AdoptionDbContext _context;

//        public ApplicationsController(IMapper mapper, AdoptionDbContext context)
//        {
//            _mapper = mapper;
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var applications = _context.Application.ToList();
//            var applicationDtos = _mapper.Map<List<Application>>(applications);
//            return Ok(applicationDtos);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<ApplicationDto> GetApplication(int id)
//        {
//            // Retrieve application from the database
//            var application = _context.Application.Find(id);
//            if (application == null)
//            {
//                return NotFound();
//            }

//            var applicationDto = _mapper.Map<Application>(application);
//            return Ok(applicationDto);
//        }

//        [HttpPost]
//        public IActionResult AddApplication(AddApplicationRequestDto addApplicationRequestDto)
//        {
//            var application = _mapper.Map<Application>(addApplicationRequestDto);

//            // Save application to the database
//            _context.Application.Add(application);
//            _context.SaveChanges();

//            var applicationDto = _mapper.Map<Application>(application);
//            return Ok(applicationDto);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateApplication(int id, UpdateApplicationRequestDto updateApplicationDto)
//        {
//            var application = _context.Application.Find(id);
//            if (application == null)
//            {
//                return NotFound();
//            }

//            // Map the updated fields from the DTO to the existing entity
//            _mapper.Map(updateApplicationDto, application);
//            _context.Entry(application).State = EntityState.Modified;
//            _context.SaveChanges();

//            var applicationDto = _mapper.Map<ApplicationDto>(application);
//            return Ok(applicationDto);
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteApplication(int id)
//        {
//            // Retrieve application from the database
//            var application = _context.Application.Find(id);
//            if (application == null)
//            {
//                return NotFound();
//            }

//            // Remove the application from the database
//            _context.Application.Remove(application);
//            _context.SaveChanges();

//            return Ok();
//        }
//    }
//}


using AutoMapper;
using FurEverHomes.Data;
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
    public class ApplicationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdoptionDbContext _context;

        public ApplicationsController(IMapper mapper, AdoptionDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .ToListAsync();

            var applicationDtos = _mapper.Map<List<ApplicationDto>>(applications);
            return Ok(applicationDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplication(int id)
        {
            var application = await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return Ok(applicationDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplication(AddApplicationRequestDto addApplicationRequestDto)
        {
            var application = _mapper.Map<Application>(addApplicationRequestDto);

            // Save application to the database
            _context.Application.Add(application);
            await _context.SaveChangesAsync();

            // Load related data
            await _context.Entry(application).Reference(a => a.Adopter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Shelter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Pet).LoadAsync();

            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return CreatedAtAction(nameof(GetApplication), new { id = applicationDto.ApplicationId }, applicationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, UpdateApplicationRequestDto updateApplicationDto)
        {
            var application = await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            // Map the updated fields from the DTO to the existing entity
            _mapper.Map(updateApplicationDto, application);
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Load related data
            await _context.Entry(application).Reference(a => a.Adopter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Shelter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Pet).LoadAsync();

            var applicationDto = _mapper.Map<ApplicationDto>(application);
            return Ok(applicationDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            // Remove the application from the database
            _context.Application.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}