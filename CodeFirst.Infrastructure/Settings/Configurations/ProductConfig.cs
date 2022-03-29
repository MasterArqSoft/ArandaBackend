using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Product");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("ProductId")
                   .HasColumnType<long>("BIGINT")
                   .HasComment("Identificador del producto")
                   .IsRequired();

            builder.Property(a => a.Name)
                   .HasColumnName("Nombre")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Nombre del producto")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Description)
                   .HasColumnName("Descripcion")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Descripción del producto")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Category)
                   .HasColumnName("Categoria")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Categoria del producto")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Images)
                   .HasColumnName("Imagen")
                   .HasColumnType<byte[]>("varbinary")
                   .HasComment("Imagen del producto")
                   .HasMaxLength(8000);
            //.IsRequired();
        }
    }
}
