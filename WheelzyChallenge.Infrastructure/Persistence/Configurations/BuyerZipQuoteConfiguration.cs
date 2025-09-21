using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class BuyerZipQuoteConfiguration : IEntityTypeConfiguration<BuyerZipQuote>
    {
        public void Configure(EntityTypeBuilder<BuyerZipQuote> builder)
        {
            builder.HasKey(bzq => bzq.Id);

            builder.Property(bzq => bzq.ZipCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(bzq => bzq.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasMany(bzq => bzq.CarQuotes)
                .WithOne(cq => cq.BuyerZipQuote)
                .HasForeignKey(cq => cq.BuyerZipQuoteId);
        }
    }
}
