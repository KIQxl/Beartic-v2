using Beartic.Auth.Entities;
using Beartic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beartic.Infraestructure.AuthContext.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasColumnType("varchar(50)");

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("email_address")
                .HasColumnType("varchar(100)");
            });

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.Firstname)
                .IsRequired()
                .HasColumnName("name_firstname")
                .HasColumnType("varchar(50)");

                name.Property(x => x.Lastname)
                .IsRequired()
                .HasColumnName("name_lastname")
                .HasColumnType("varchar(50)");
            });

            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasColumnType("varchar(11)")
                .IsFixedLength(true);
            });

            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("password_hash")
                .HasColumnType("varchar(100)");

                password.Property(x => x.SaltKey)
                .IsRequired()
                .HasColumnName("password_key")
                .HasColumnType("varchar(100)");
            });

            builder.OwnsOne(x => x.Document, document =>
            {
                document.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("document_number")
                .HasColumnType("varchar(14)");

                document.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("document_type")
                .HasColumnType("int");
            });

            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "user_role",

                role => role.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("role_id")
                    .HasConstraintName("FK_role_userRole")
                    .OnDelete(DeleteBehavior.Cascade),

                user => user.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("user_id")
                    .HasConstraintName("FK_user_userRole")
                    .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
