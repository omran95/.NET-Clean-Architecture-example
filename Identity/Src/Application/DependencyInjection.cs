using FluentValidation;
using MediatR;

using System.Reflection;
using Identity.Src.Application.Common.Behaviors;


namespace Identity.Src.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(IdentityValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}

