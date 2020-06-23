using Microsoft.Extensions.DependencyInjection;
using segundoparcial_mtorres.Business;
using segundoparcial_mtorres.Contracts;
using segundoparcial_mtorres.DAL;
using segundoparcial_mtorres.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection source)
        {
            var genericType = typeof(IGenericService<>).GetGenericTypeDefinition();
            var contractsTypes = typeof(IGenericService<>).Assembly.GetTypes(t => t.IsInterface && t.ImplementsGenericInterface(genericType));

            foreach (var contractType in contractsTypes)
            {
                var implementationType = typeof(GenericService<>).Assembly.FindType(t => t.IsClass && contractType.IsAssignableFrom(t));
                if (implementationType != null)
                {
                    source.AddTransient(contractType, implementationType);
                }
            }
            return source;
        }
    }
}