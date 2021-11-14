using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolBusWebApi.Helpers;
using SchoolBusWebApi.Repositories;
using SchoolBusWebApi.Services;
using SchoolBusWebApi.Interface;
using SchoolBusWebApi.Repositories.Core;

namespace SchoolBusWebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Config)
        {

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBusinessUnitOfWork, BusinessUnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);



            IServiceCollection serviceCollection = services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(
                    Config.GetConnectionString("DefaultConnection")
                    ));

            return services;
        }
    }
}
