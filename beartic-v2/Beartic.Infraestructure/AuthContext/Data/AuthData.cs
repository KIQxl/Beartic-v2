using Beartic.Auth.Entities;
using Beartic.Auth.ValueObjects;
using Beartic.Core.Entities;
using Beartic.Infraestructure.AuthContext.Mappings;
using Beartic.Shared.ValueObjects;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.AuthContext.Data
{
    public class AuthData : DbContext
    {
        public AuthData(DbContextOptions<AuthData> opts) : base(opts)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<User>().HasData(new User("Default-User", new Name("Default", "User"), new Email("defaultuser@email.com"), new Document("", Shared.Enums.EDocumentType.CPF), new Phone(""), new Password("Kaique1998@")));
            modelBuilder.Entity<Role>().HasData(new Role("Deafult-Role", true));
        }
    } 
}