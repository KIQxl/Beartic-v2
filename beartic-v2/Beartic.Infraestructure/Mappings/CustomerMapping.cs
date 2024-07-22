using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.Mappings
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
                .HasColumnName("Firstname");

                name.Property(n => n.Lastname)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("Lastname");
            });

            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("varchar(11)")
                .HasColumnName("Phone_Number");
            });

            builder.OwnsOne(x => x.Document, document =>
            {
                document.Property(d => d.Number)
                .IsRequired()
                .HasColumnType("varchar(14)")
                .HasColumnName("Document_Number");

                document.Property(d => d.Type)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Document_Type");
            });

            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(p => p.PasswordHash)
                 .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Password_Hash");

                password.Property(p => p.SaltKey)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Salt_Key");
            });

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Address)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Email_Address");
            });

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Address_Street");

                address.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Address_City");

                address.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Address_State");

                address.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasColumnName("Address_ZipCode");

                address.Property(a => a.Country)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("Address_Country");

                address.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasColumnName("Address_Number");
            });

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer);
        }
    }
}
