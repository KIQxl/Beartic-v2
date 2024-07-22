using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("Create_Date");

            builder.Property(x => x.ModifiedAt)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("Modification_Date");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Status");

            builder.OwnsOne(x => x.Installment, installment =>
            {
                installment.Property(i => i.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("Price");

                installment.Property(i => i.Installments)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Installments");

                installment.Property(i => i.InstallmentPrice)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("Installment_Price");

                installment.Property(i => i.ModifiedAt)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("Installment_Modification_Date");
            });
        }
    }
}
