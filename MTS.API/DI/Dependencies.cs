using Microsoft.Extensions.DependencyInjection;
using MTS.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.API.DI
{
    /// <summary>
    /// Manage dependencies of project
    /// </summary>
    public static class Dependencies
    {
        /// <summary>
        /// Mathod for manage dependencies of project
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<IBaseRepo, BaseRepo>();
        }
    }
}
