//using FurEverHomes.Models.Domain;
//using Microsoft.EntityFrameworkCore;

//namespace FurEverHomes.Data
//{
//    public class AdoptionDbContext : DbContext
//    {
//        public AdoptionDbContext(DbContextOptions<AdoptionDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Pet> Pets { get; set; }
//        public DbSet<Shelter> Shelters { get; set; }
//        public DbSet<Adopter> Adopters { get; set; }
//        public DbSet<Application> Applications { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Pet and Application relationship
//            modelBuilder.Entity<Pet>()
//                .HasOne(p => p.Application)
//                .WithMany()
//                .HasForeignKey(p => p.ApplicationId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete application when pet is deleted

//            // Pet and Shelter relationship
//            modelBuilder.Entity<Pet>()
//                .HasOne(p => p.Shelter)
//                .WithMany(s => s.Pets)
//                .HasForeignKey(p => p.ShelterId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete pets when shelter is deleted

//            // Shelter and Application relationship
//            modelBuilder.Entity<Shelter>()
//                .HasMany(s => s.Applications)
//                .WithOne(a => a.Shelter)
//                .HasForeignKey(a => a.ShelterId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete applications when shelter is deleted

//            // Adopter and Application relationship
//            modelBuilder.Entity<Adopter>()
//                .HasMany(a => a.Applications)
//                .WithOne(a => a.Adopter)
//                .HasForeignKey(a => a.AdopterId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete applications when adopter is deleted

//            // Application and Pet relationship
//            modelBuilder.Entity<Application>()
//                .HasOne(a => a.Pet)
//                .WithMany()
//                .HasForeignKey(a => a.PetId)
//                .OnDelete(DeleteBehavior.SetNull); // Set PetId to null when application is deleted

//            // Application and Shelter relationship
//            modelBuilder.Entity<Application>()
//                .HasOne(a => a.Shelter)
//                .WithMany(s => s.Applications)
//                .HasForeignKey(a => a.ShelterId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete applications when shelter is deleted

//            // Application and Adopter relationship
//            modelBuilder.Entity<Application>()
//                .HasOne(a => a.Adopter)
//                .WithMany(ad => ad.Applications)
//                .HasForeignKey(a => a.AdopterId)
//                .OnDelete(DeleteBehavior.Cascade); // Delete applications when adopter is deleted
//        }
//    }
//}


using FurEverHomes.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FurEverHomes.Data
{
    public class AdoptionDbContext : DbContext
    {
        public AdoptionDbContext(DbContextOptions<AdoptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Pet and Application relationship
            //modelBuilder.Entity<Pet>()
            //    .HasOne(p => p.Application)
            //    .WithMany()
            //    .HasForeignKey(p => p.ApplicationId)
            //    .OnDelete(DeleteBehavior.Cascade); // Delete application when pet is deleted

            // Pet and Shelter relationship
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Shelter)
                .WithMany(s => s.Pets)
                .HasForeignKey(p => p.ShelterId)
                .OnDelete(DeleteBehavior.Cascade); // Delete pets when shelter is deleted

            //Shelter and Application relationship
            //modelBuilder.Entity<Shelter>()
            //    .HasMany(s => s.Applications)
            //    .WithOne(a => a.Shelter)
            //    .HasForeignKey(a => a.ApplicationId)
            //    .OnDelete(DeleteBehavior.Cascade); // Delete applications when shelter is deleted

            // Adopter and Application relationship
            modelBuilder.Entity<Adopter>()
                .HasMany(a => a.Applications)
                .WithOne(a => a.Adopter)
                .HasForeignKey(a => a.AdopterId)
                .OnDelete(DeleteBehavior.Cascade); // Delete applications when adopter is deleted

            // Application and Pet relationship
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Applications)
                .HasForeignKey(a => a.PetId) 
                .OnDelete(DeleteBehavior.Cascade); // Set PetId to null when application is deleted

            //// Application and Shelter relationship
            //modelBuilder.Entity<Application>()
            //    .HasOne(a => a.Shelter)
            //    .WithMany(s => s.Applications)
            //    .HasForeignKey(a => a.ShelterId)
            //    .OnDelete(DeleteBehavior.Cascade); // Delete applications when shelter is deleted

            // Application and Adopter relationship
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Adopter)
                .WithMany(ad => ad.Applications)
                .HasForeignKey(a => a.AdopterId)
                .OnDelete(DeleteBehavior.Cascade); // Delete applications when adopter is deleted
        }
    }
}