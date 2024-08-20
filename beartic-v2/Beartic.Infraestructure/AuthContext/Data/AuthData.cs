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

            //modelBuilder.Entity<User>().HasData(new User("Default-User", new Name("Default", "User"), new Email("defaultuser@email.com"), new Document("87778018063", EDocumentType.CPF), new Phone("11977268607"), new Password("123456789k@")));
            modelBuilder.Entity<Role>().HasData(new Role("Default-Role", true));

            modelBuilder.Entity<User>().HasData(new
            {
                Id = Guid.NewGuid(), // Se necessário, substitua pelo ID correto.
                Username = "Default-User",
                Email_Address = "defaultuser@email.com",
                Name_Firstname = "Default",
                Name_Lastname = "User",
                Phone_Number = "11977268607",
                Password_Hash = "123456789k@",  // Hash adequado
                Password_Key = "SomeSalt",     // Salt adequado
                Document_Number = "87778018063",
                Document_Type = (int)EDocumentType.CPF, // Enum como int
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=localhost; database=beartic-v2;user=root;password=123456;", ServerVersion.AutoDetect("server=localhost; database=beartic-v2;user=root;password=123456;"))
                .EnableSensitiveDataLogging(); // Ativar logging de dados sensíveis
        }

    } 
}