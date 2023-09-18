using Identity.Src.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;
using Mapster;
using MapsterMapper;

namespace Identity.Src.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, IdentityProblemDetailsFactory>();
        services.AddMapping();
        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}

