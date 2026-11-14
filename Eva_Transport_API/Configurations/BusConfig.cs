using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class BusConfig : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("Buses");

            #region Properties

            builder.Property(b => b.PlateNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Capacity)
                .IsRequired();
            builder.Property(b => b.Status)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion

            #region Relationships

            //BusDriver
            builder.HasMany(b => b.busDrivers)
                .WithMany(d => d.buses);

            //Reports
            builder.HasMany(b => b.reports)
                .WithOne(r => r.bus)
                .HasForeignKey(r => r.BusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Trips
            builder.HasMany(b => b.busTrips)
                .WithOne(t => t.bus)
                .HasForeignKey(t => t.BusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Company
            builder.HasOne(b => b.company)
                .WithMany(c => c.buses)
                .HasForeignKey(b => b.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
