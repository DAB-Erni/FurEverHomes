using FurEverHomes.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FurEverHomes.Data
{
    public class AdoptionDbContext: DbContext
    {
        public AdoptionDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Adopters> Adopters { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<Application> Application { get; set; }

    }
}
