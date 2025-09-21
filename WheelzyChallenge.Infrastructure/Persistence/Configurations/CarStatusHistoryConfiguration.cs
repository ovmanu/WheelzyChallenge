using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class CarStatusHistoryConfiguration : IEntityTypeConfiguration<CarStatusHistory>
    {
        public void Configure(EntityTypeBuilder<CarStatusHistory> builder)
        {
            builder.HasKey(csh => csh.Id);

            builder.Property(csh => csh.ChangedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(csh => csh.StatusDate)
                .IsRequired(false);

            builder.Property(csh => csh.IsCurrent)
                .IsRequired();

            builder.HasOne(csh => csh.Car)
                .WithMany(c => c.StatusHistory)
                .HasForeignKey(csh => csh.CarId);

            builder.HasOne(csh => csh.Status)
                .WithMany(s => s.CarStatusHistories)
                .HasForeignKey(csh => csh.StatusId);
        }
    }
}
