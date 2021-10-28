using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolBusWebService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Config)
        {
          
            IServiceCollection serviceCollection = services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(
                    Config.GetConnectionString("DefaultConnection")
                    ));

            return services;
        }
    }
}
