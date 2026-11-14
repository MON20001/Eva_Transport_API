using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class BusMaintenanceRequestConfig : IEntityTypeConfiguration<BusMaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<BusMaintenanceRequest> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("BusReports");

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
