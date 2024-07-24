using Beartic.Core.Entities;
using Beartic.Infraestructure.AuthContext.Mappings;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.AuthContext.DataContext
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> opts) : base(opts)
        {

        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.Ignore<Notification>();
        }
    } 
}