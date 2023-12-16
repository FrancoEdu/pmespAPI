using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pmesp.Application.Interfaces;
using pmesp.Application.Mappings;
using pmesp.Application.Services;
using pmesp.Domain.Interfaces.Bandits;
using pmesp.Domain.Interfaces.Irg;
using pmesp.Infrastructure.Context;
using pmesp.Infrastructure.Repositories;
using System;

namespace pmesp.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        string sqlConnection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));

        services.AddScoped<IBanditRepository, BanditRepository>();
        services.AddScoped<IBanditService, BanditService>();
        services.AddScoped<IRgRepository, RgRepository>();
        services.AddScoped<IRgsService,RgService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
