using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class BusDriverConfig : IEntityTypeConfiguration<BusDriver>
    {
        public void Configure(EntityTypeBuilder<BusDriver> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("BusDrivers");

            #region Properties

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.LicenseNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Status)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Phone)
                .IsRequired()
                .HasMaxLength(11);

            #endregion
        }
    }
}
