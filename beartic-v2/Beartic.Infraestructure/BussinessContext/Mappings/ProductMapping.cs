using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.BussinessContext.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Title");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(500)")
                .HasColumnName("Description");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("Price");

            builder.Property(x => x.QuantityOnHand)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("QuantityOnHand");

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Products)
                .UsingEntity<Dictionary<string, object>>(
                "Product_Category",

                category => category.HasOne<Category>()
                .WithMany()
                .HasForeignKey("category_id")
                .HasConstraintName("FK_category_productCategory")
                .OnDelete(DeleteBehavior.Cascade),

                product => product.HasOne<Product>()
                .WithMany()
                .HasForeignKey("product_id")
                .HasConstraintName("FK_product_productCategory")
                .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}
