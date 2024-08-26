namespace BoatSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Entities;
    using BoatSystem.Core.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        }
    }


    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.HasKey(c => c.Id);

            builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(m => m.UserId).IsRequired();
        }
    }


    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(c => c.Id);

            builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(m => m.UserId).IsRequired();
        }
    }
}
