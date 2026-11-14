using Eva_Transport_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eva_Transport_API.Configurations
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Companies");

            #region Properties

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(11);

            #endregion

            #region Relationships

            builder.HasMany(c => c.buses)
                .WithOne(b => b.company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.trucks)
                .WithOne(t => t.company)
                .HasForeignKey(t => t.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.employees)
                .WithOne(e => e.company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
