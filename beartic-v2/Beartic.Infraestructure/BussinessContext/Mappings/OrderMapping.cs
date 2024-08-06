using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.BussinessContext.Mappings
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
                .HasColumnName("create_Date");

            builder.Property(x => x.ModifiedAt)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("modification_Date");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("status");

            builder.OwnsOne(x => x.Installment, installment =>
            {
                installment.Property(i => i.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("price");

                installment.Property(i => i.Installments)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("installments");

                installment.Property(i => i.InstallmentPrice)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("installment_price");

                installment.Property(i => i.ModifiedAt)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("installment_modification_date");
            });
        }
    }
}
