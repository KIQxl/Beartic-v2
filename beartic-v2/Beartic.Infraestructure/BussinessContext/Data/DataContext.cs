using Beartic.Core.Entities;
using Beartic.Infraestructure.BussinessContext.Mappings;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Infraestructure.BussinessContext.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.Ignore<Notification>();
        }
    }
}
