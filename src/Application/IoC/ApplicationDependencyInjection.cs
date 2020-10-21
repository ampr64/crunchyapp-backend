using Microsoft.Extensions.DependencyInjection;
using CrunchyAppBackend.Common.Extensions;
using CrunchyAppBackend.Core.Contracts;
using CrunchyAppBackend.Application.Services;

namespace CrunchyAppBackend.Application.IoC
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var genericType = typeof(IGenericService<>).GetGenericTypeDefinition();
            var serviceInterfaceTypes = typeof(IGenericService<>)
                .Assembly
                .GetTypes(t => t.IsInterface && t.ImplementsGenericInterface(genericType));

            foreach (var interfaceType in serviceInterfaceTypes)
            {
                var implementationType = typeof(GenericService<>)
                    .Assembly
                    .FindType(t => t.IsClass && interfaceType.IsAssignableFrom(t));

                if (implementationType != null)
                {
                    services.AddTransient(interfaceType, implementationType);
                }
            }
            return services;
        }
    }
}