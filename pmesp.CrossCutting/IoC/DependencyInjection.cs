using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using pmesp.Application.Interfaces.Bandits;
using pmesp.Application.Interfaces.Cop;
using pmesp.Application.Interfaces.RGs;
using pmesp.Application.Mappings;
using pmesp.Application.Services.Bandits;
using pmesp.Application.Services.Cops;
using pmesp.Application.Services.RGs;
using pmesp.Domain.Entities.Cops.Account;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Domain.Interfaces.ICop;
using pmesp.Domain.Interfaces.Irg;
using pmesp.Infrastructure.Context;
using pmesp.Infrastructure.Identity;
using pmesp.Infrastructure.Repositories.Bandits;
using pmesp.Infrastructure.Repositories.Cops;
using pmesp.Infrastructure.Repositories.RGs;
using System;
using System.Text;

namespace pmesp.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        string sqlConnection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));

        // Configurando autenticação e JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
        ).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["Jwt:issuer"],
                ValidAudience = configuration["Jwt:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:secretKey"])
                )
            };
        });
       
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        // Repository
        services.AddScoped<IBanditRepository, BanditRepository>();
        services.AddScoped<IRgRepository, RgRepository>();
        services.AddScoped<ICopRepository, CopsRepository>();
        services.AddScoped<IAuthenticate, IdentityRepository>();
        
        // Services
        services.AddScoped<IBanditService, BanditService>();
        services.AddScoped<IRgsService,RgService>();
        services.AddScoped<ICopService,CopService>();


        return services;
    }
}
