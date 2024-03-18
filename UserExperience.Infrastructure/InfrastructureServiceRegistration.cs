using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Logging;
using UserExperience.Infrastructure.Logging;

namespace UserExperience.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }


    }
}
