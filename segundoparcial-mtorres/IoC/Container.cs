using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.IoC
{
    public static class Container
    {
        public static IServiceCollection ConfigureIoC(this IServiceCollection services)
        {
            services.AddBusinessLayer();
            return services;
        }
    }
}
