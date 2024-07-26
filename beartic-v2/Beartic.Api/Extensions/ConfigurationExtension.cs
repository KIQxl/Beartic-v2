using Beartic.Auth.Interfaces;
using Beartic.Core.Interfaces;
using Beartic.Infraestructure.AuthContext.Repositories;
using Beartic.Infraestructure.BussinessContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddContexts(this IServiceCollection services)
        {
            services.AddDbContext<Infraestructure.BussinessContext.Data.BussinessData>(opts => opts.UseSqlServer("", b => b.MigrationsAssembly("Beartic.Api")));
            services.AddDbContext<Infraestructure.AuthContext.Data.AuthData>(opts => opts.UseSqlServer("", b => b.MigrationsAssembly("Beartic.Api")));
        }

        public static void AddDependenceInjections(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepositoy>();
        }
    }
}
