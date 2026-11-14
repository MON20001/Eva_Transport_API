using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class TruckTripConfig : IEntityTypeConfiguration<TruckTrip>
    {
        public void Configure(EntityTypeBuilder<TruckTrip> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("TruckTrips");

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
