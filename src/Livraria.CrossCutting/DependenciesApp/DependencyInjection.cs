using Livraria.Domain.Abstractions;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.CrossCutting.DependenciesApp;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LivrariaContext");

        services.AddDbContext<LivrariaContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<ILivroRepository, LivroRepository>();

        return services;
    }
}