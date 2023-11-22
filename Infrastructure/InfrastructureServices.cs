using Application.Shared.Interfaces;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LocalConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
