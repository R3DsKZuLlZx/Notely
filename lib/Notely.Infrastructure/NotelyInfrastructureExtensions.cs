using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Notely.Application.Common.Interfaces;
using Notely.Application.Notes;
using Notely.Infrastructure.Database;
using Notely.Infrastructure.Database.Repositories;

namespace Notely.Infrastructure;

public static class NotelyInfrastructureExtensions
{
    public static IServiceCollection AddNotelyInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
        });
        
        serviceCollection.AddHealthChecks().AddCustomHealthChecks(Assembly.GetExecutingAssembly());
        
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<INoteRepository, NoteRepository>();
        
        return serviceCollection;
    }
    
    private static IHealthChecksBuilder AddCustomHealthChecks(
        this IHealthChecksBuilder builder, 
        Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => !x.IsInterface)
            .Where(x => !x.IsGenericTypeDefinition) 
            .Where(x => x.IsAssignableTo(typeof(IHealthCheck)))
            .ToArray();
             
        foreach (var type in types)
        {
            var registration = new HealthCheckRegistration(
                type.Name,
                provider => (IHealthCheck)ActivatorUtilities.GetServiceOrCreateInstance(provider, type),
                null,
                null);
            
            builder.Add(registration);
        }
             
        return builder;
    }
}
