using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.RoleUseCases;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CategoryUseCases;
using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Core.UseCases.OrderUseCases;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Infraestructure.AuthContext.Repositories;
using Beartic.Infraestructure.BussinessContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Beartic.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddContexts(this IServiceCollection services)
        {
            services.AddDbContext<Infraestructure.BussinessContext.Data.BussinessData>(opts => opts.UseMySql("server=localhost; database=beartic-v2;user=root;password=123456", ServerVersion.AutoDetect("server=localhost; database=beartic-v2;user=root;password=123456"), b => b.MigrationsAssembly("Beartic.Api")));
            services.AddDbContext<Infraestructure.AuthContext.Data.AuthData>(opts => opts.UseMySql("server=localhost; database=beartic-v2;user=root;password=123456", ServerVersion.AutoDetect("server=localhost; database=beartic-v2;user=root;password=123456"), b => b.MigrationsAssembly("Beartic.Api")));
        }

        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepositoy>();
        }

        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleServices, RoleServices>();
        }
    }
}
