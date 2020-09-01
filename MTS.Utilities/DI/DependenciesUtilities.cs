using Microsoft.Extensions.DependencyInjection;

namespace MTS.Utilities.DI
{
    public static class DependenciesUtilities
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<IGenerateID, GenerateID>();
        }
    }
}
