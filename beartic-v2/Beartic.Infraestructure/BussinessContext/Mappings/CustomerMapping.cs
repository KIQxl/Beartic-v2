using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.BussinessContext.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Firstname)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("name_firstname");

                name.Property(n => n.Lastname)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("name_lastname");
            });

            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(11)")
                .HasColumnName("phone_number");
            });

            builder.OwnsOne(x => x.Document, document =>
            {
                document.Property(d => d.Number)
                .IsRequired()
                .HasColumnType("varchar(14)")
                .HasColumnName("document_number");

                document.Property(d => d.Type)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("document_type");
            });

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Address)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("email_address");
            });

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("address_street");

                address.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("address_city");

                address.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("address_state");

                address.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasColumnName("address_zipCode");

                address.Property(a => a.Country)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("address_country");

                address.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasColumnName("address_number");
            });

            //builder.HasIndex(x => x.Email.Address).IsUnique();
            //builder.HasIndex(x => x.Phone.Number).IsUnique();
            //builder.HasIndex(x => x.Document.Number).IsUnique();

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer);
        }
    }
}
