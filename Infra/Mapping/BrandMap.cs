using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Code)
                .HasColumnName("Code")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(u => u.Description)
                .HasColumnName("Description")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
