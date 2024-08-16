using Beartic.Auth.Entities;
using Beartic.Auth.ValueObjects;
using Beartic.Core.Entities;
using Beartic.Infraestructure.AuthContext.Mappings;
using Beartic.Shared.Enums;
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

            modelBuilder.Entity<User>().HasData(new User("Default-User", new Name("Default", "User"), new Email("defaultuser@email.com"), new Document("45261517850", EDocumentType.CPF), new Phone("11977268607"), new Password("Kaique1998@")));
            modelBuilder.Entity<Role>().HasData(new Role("Deafult-Role", true));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=localhost; database=beartic-v2;user=root;password=123456;", ServerVersion.AutoDetect("server=localhost; database=beartic-v2;user=root;password=123456;"))
                .EnableSensitiveDataLogging(); // Ativar logging de dados sensíveis
        }

    } 
}