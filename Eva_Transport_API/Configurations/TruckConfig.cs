using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class TruckConfig : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("Trucks");

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
            builder.HasMany(b => b.truckDrivers)
                .WithMany(d => d.trucks);

            //Reports
            builder.HasMany(b => b.reports)
                .WithOne(r => r.truck)
                .HasForeignKey(r => r.TruckId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Trips
            builder.HasMany(b => b.trucktrips)
                .WithOne(t => t.truck)
                .HasForeignKey(t => t.TruckId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //Company
            builder.HasOne(b => b.company)
                .WithMany(c => c.trucks)
                .HasForeignKey(b => b.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
