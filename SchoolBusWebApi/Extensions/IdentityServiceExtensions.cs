using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServiceExtensions(this IServiceCollection services, IConfiguration Config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                      .AddJwtBearer(option =>
                      {
                          option.TokenValidationParameters = new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["TokenKey"])),
                              ValidateAudience = false,
                              ValidateIssuer = false
                          };
                      }
                      );

            return services;
        }
    }
}
