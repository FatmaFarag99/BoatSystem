namespace BoatRentalSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Models;
    using BoatSystem.Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityConfiguration());


            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasData(new IdentityRole
                {
                    Id = "7bdb9275-8cd4-4d86-bea6-bbdb5125e28a",
                    Name = "Admin",
                    NormalizedName = "ADMIN"

                });


                entity.HasData(new IdentityRole
                {
                    Id = "f117b498-2e53-4686-86dc-d3c13072850e",
                    Name = "User",
                    NormalizedName = "USER"

                });
            });
        }
    }
}
