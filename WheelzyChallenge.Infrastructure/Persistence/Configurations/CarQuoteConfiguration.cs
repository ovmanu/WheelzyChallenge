using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class CarQuoteConfiguration : IEntityTypeConfiguration<CarQuote>
    {
        public void Configure(EntityTypeBuilder<CarQuote> builder)
        {
            builder.HasKey(cq => cq.Id);

            builder.Property(cq => cq.IsCurrent)
                .IsRequired();

            builder.HasOne(cq => cq.Car)
                .WithMany(c => c.Quotes)
                .HasForeignKey(cq => cq.CarId);

            builder.HasOne(cq => cq.BuyerZipQuote)
                .WithMany(bzq => bzq.CarQuotes)
                .HasForeignKey(cq => cq.BuyerZipQuoteId);
        }
    }
}
