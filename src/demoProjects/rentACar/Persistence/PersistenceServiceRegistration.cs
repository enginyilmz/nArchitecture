using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Extensions;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseNpgsql(
                                                         configuration.GetConnectionString("RentACarCampConnectionString"),
                                                         //configuration.GetConnectionStringFromEnviroment(),
                                                         option =>
                                                         {
                                                             option.MigrationsAssembly(Assembly.GetAssembly(typeof(BaseDbContext)).GetName().Name);
                                                             AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                                                         }));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
