 using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class TruckMaintenanceRequestConfig : IEntityTypeConfiguration<TruckMaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<TruckMaintenanceRequest> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("TruckReports");

            #region Properties

            builder.Property(b => b.IssueDescription)
                .HasMaxLength(200);
            builder.Property(b => b.RequestDate)
                .IsRequired();
            builder.Property(b => b.Status)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion
        }
    }
}
