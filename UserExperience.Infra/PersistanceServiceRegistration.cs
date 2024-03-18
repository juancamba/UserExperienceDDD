using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Infra.Persistence.DatabaseContext.Repositories;
using UserExperience.Infra.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace UserExperience.Infra.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WEDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WEDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkingexperienceRepository, WorkingexperienceRepository>();

            return services;
        }
    }
}
