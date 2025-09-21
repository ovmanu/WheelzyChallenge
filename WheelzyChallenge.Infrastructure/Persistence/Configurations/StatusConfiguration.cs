using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(s => s.CarStatusHistories)
                .WithOne(csh => csh.Status)
                .HasForeignKey(csh => csh.StatusId);
        }
    }
}
