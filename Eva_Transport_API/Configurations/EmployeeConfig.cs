using Eva_Transport_API.Models;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("Employees");

            #region Properties

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.PickupLocation)
                .IsRequired();
            builder.Property(b => b.Phone)
                .IsRequired()
                .HasMaxLength(11);

            #endregion

            #region Relationships

            // Bus Trips
            builder.HasMany(e => e.employeeBusTrips)
                .WithMany(t => t.employees)
                .UsingEntity(j => j.ToTable("BusTripEmployee"));

            //Company
            builder.HasOne(b => b.company)
                .WithMany(c => c.employees)
                .HasForeignKey(b => b.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
