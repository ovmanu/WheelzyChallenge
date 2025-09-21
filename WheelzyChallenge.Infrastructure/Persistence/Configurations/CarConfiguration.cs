using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.SubModel)
                .HasMaxLength(50);

            builder.Property(c => c.ZipCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(c => c.Quotes)
                .WithOne(q => q.Car)
                .HasForeignKey(q => q.CarId);

            builder.HasMany(c => c.StatusHistory)
                .WithOne(sh => sh.Car)
                .HasForeignKey(sh => sh.CarId);
        }
    }
}
