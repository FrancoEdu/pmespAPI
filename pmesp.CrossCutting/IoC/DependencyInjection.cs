using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pmesp.Infrastructure.Context;
using System;

namespace pmesp.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        string sqlConnection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));

        return services;
    }
}
