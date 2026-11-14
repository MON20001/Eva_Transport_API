using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class BusTripConfig : IEntityTypeConfiguration<BusTrip>
    {
        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("BusTrips");

            #region Properties

            builder.Property(b => b.StartTime)
                .IsRequired();
            builder.Property(b => b.EndTime)
                .IsRequired();
            builder.Property(b => b.TripDate)
               .IsRequired();
            builder.Property(b => b.Status)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion
        }
    }
}
