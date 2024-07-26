using Beartic.Auth.Entities;
using Beartic.Core.Entities;
using Beartic.Infraestructure.AuthContext.Mappings;
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
        }
    } 
}