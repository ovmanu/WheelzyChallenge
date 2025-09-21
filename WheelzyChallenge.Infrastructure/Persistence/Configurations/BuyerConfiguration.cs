using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.BuyerZipQuotes)
                .WithOne(z => z.Buyer)
                .HasForeignKey(z => z.BuyerId);
        }
    }
}
