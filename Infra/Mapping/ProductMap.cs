using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Description)
                .HasColumnName("Description")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(u => u.BrandId)
                .HasColumnName("BrandId")
                .IsRequired();
        }
    }
}
