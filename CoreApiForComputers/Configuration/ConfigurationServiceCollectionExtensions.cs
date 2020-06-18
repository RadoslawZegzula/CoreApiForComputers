using CoreApiForComputers.DataBase.EntityImplementations;
using CoreApiForComputers.DataBase.EntityInterfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class clean up Startup.cs dependencies
    /// </summary>
    public static class ConfigurationServiceCollectionExtensions
    {
        /// <summary>
        /// Contains repository configurations
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICpuRepository, CpuMemoryRepository>();

            return services;
        }
    }
}
