using Beartic.Api.Services;
using Beartic.Api.Services.ServicesModels;
using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.LoginUseCases;
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
            services.AddScoped<ILoginServices, LoginServices>();
        }

        public static void AddJwtSecurity(this WebApplicationBuilder builder)
        {
            var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

            var byteKey = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(byteKey),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer
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
