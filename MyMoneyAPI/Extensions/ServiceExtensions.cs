using Microsoft.EntityFrameworkCore;
using MyMoneyAPI.Data;
using MyMoneyAPI.Services.Interfaces;
using MyMoneyAPI.Services;
using System.Reflection;

namespace MyMoneyAPI.Extensions
{
    public static class ServiceExtensions
    {
        // Method to register services
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure EF Core with SQL Server
            // Register ApplicationDbContext with connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Register services (Add all your services here)
            services.AddScoped<IAccountService, AccountService>();
        }

        // Method to configure Swagger
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                
                c.EnableAnnotations(); // Enable Swagger annotations
            });
        }

    }
}
