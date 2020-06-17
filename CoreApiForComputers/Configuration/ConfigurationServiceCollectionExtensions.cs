using CoreApiForComputers.DataBase;

namespace Microsoft.Extensions.DependencyInjection 
{
    /// <summary>
    /// This class clean up Startup.cs dependencies
    /// </summary>
    public static class ConfigurationServiceCollectionExtensions
    {
        /// <summary>
        /// Contains database configurations
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataModelsConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepository, MemoryRepository>();

            return services;
        }
    }
}
