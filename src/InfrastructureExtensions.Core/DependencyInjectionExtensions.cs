using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InfrastructureExtensions.Core;

public static class DependencyInjectionExtensions
{
    public static void AddSingle(
        this IServiceCollection services,
        Type serviceType,
        Type implementationType,
        ServiceLifetime lifetime)
    {
        var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
        services.RemoveAll(serviceType).Add(descriptor);
    }
}