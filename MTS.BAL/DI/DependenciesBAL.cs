using Microsoft.Extensions.DependencyInjection;
using MTS.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.BAL.DI
{
    public static class DependenciesBAL
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<IMTSRepo, MTSRepo>();
        }
    }
}
