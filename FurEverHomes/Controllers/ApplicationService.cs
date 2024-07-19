//using FurEverHomes.Models.Domain;
//using FurEverHomes.Data; // Assuming you have a data context
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace FurEverHomes.Services
//{
//    public interface IApplicationService
//    {
//        Task<Application> AddApplicationAsync(Application application);
//        Task<IEnumerable<Application>> GetAllApplicationsAsync();
//    }

//    public class ApplicationService : IApplicationService
//    {
//        private readonly AdoptionDbContext _context;

//        public ApplicationService(AdoptionDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Application> AddApplicationAsync(Application application)
//        {
//            _context.Application.Add(application);
//            await _context.SaveChangesAsync();

//            // Load related data
//            await _context.Entry(application).Reference(a => a.Adopter).LoadAsync();
//            await _context.Entry(application).Reference(a => a.Shelter).LoadAsync();
//            await _context.Entry(application).Reference(a => a.Pet).LoadAsync();

//            return application;
//        }

//        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
//        {
//            return await _context.Application
//                .Include(a => a.Adopter)
//                .Include(a => a.Shelter)
//                .Include(a => a.Pet)
//                .ToListAsync();
//        }
//    }
//}

using FurEverHomes.Models.Domain;
using FurEverHomes.Data; // Assuming you have a data context
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurEverHomes.Services
{
    public interface IApplicationService
    {
        Task<Application> AddApplicationAsync(Application application);
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
        Task<Application> UpdateApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(Application application);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly AdoptionDbContext _context;

        public ApplicationService(AdoptionDbContext context)
        {
            _context = context;
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            _context.Application.Add(application);
            await _context.SaveChangesAsync();

            // Load related data
            await _context.Entry(application).Reference(a => a.Adopter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Shelter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Pet).LoadAsync();

            return application;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            return await _context.Application
                .Include(a => a.Adopter)
                .Include(a => a.Shelter)
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.ApplicationId == id);
        }

        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            _context.Application.Update(application);
            await _context.SaveChangesAsync();

            // Load related data
            await _context.Entry(application).Reference(a => a.Adopter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Shelter).LoadAsync();
            await _context.Entry(application).Reference(a => a.Pet).LoadAsync();

            return application;
        }

        public async Task<bool> DeleteApplicationAsync(Application application)
        {
            _context.Application.Remove(application);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}