using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyMoneyAPI.Data;
using MyMoneyAPI.Extensions;

namespace MyMoneyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Web API Services to the application
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddApplicationServices(builder.Configuration);  // Services setup (DbContext, Repos, etc.)
            builder.Services.AddSwagger();                                   // Swagger setup

            var app = builder.Build();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    // Set Swagger as the default launch page
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty; // Set the Swagger UI at the root of the application
                });
            }

            //Routing
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
