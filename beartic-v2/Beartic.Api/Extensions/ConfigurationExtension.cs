using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.RoleUseCases;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CategoryUseCases;
using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Core.UseCases.OrderUseCases;
using Beartic.Core.UseCases.ProductUseCases;
using Beartic.Infraestructure.AuthContext.Data;
using Beartic.Infraestructure.AuthContext.Repositories;
using Beartic.Infraestructure.BussinessContext.Data;
using Beartic.Infraestructure.BussinessContext.Repositories;
using Beartic.Infraestructure.Transactions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Beartic.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BussinessData>(opts => opts.UseMySql(configuration.GetConnectionString("Beartic-v2"), ServerVersion.AutoDetect(configuration.GetConnectionString("Beartic-v2")), b => b.MigrationsAssembly("Beartic.Api")));
            services.AddDbContext<AuthData>(opts => opts.UseMySql(configuration.GetConnectionString("Beartic-v2"), ServerVersion.AutoDetect(configuration.GetConnectionString("Beartic-v2")), b => b.MigrationsAssembly("Beartic.Api")));
        }

        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepositoy>();
            services.AddTransient<IUow, Uow>();
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

        public static void AddJwtSecurity(this WebApplicationBuilder builder, string key)
        {
            var byteKey = Encoding.ASCII.GetBytes(key);
            var symmetricSecurityKey = new SymmetricSecurityKey(byteKey);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void AddAppConfig(this WebApplication app)
        {
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
