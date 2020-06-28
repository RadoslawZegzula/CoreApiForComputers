using CoreApiForComputers.DataBase.EntityImplementations;
using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;

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
            services.AddScoped(typeof(ICpuRepository<>), typeof(CpuEntityRepository<>));

            return services;
        }
    }
}
