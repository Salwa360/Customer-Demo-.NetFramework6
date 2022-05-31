using BasicData.Infrastructure.Persistence;
using BasicData.Infrastructure.Seeds;
using BasicData.Infrastructure.Services.Implementions;
using BasicData.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasicDataOfCustomers.Infrastructure.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<SeedCustomerDataAsync>();
            services.AddTransient<ICustomerServiceAsync, CustomerServiceAsync>();
            return services;
        }
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            //Enable seeding data

            /*using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                SeedCustomerDataAsync.SeedCustomerData(context);
                return app;

            }
            catch (Exception ex)
            {

            }*/

            return app;
        }

    }
}
