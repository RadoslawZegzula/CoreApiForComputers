using CoreApiForComputers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreApiForComputers.DataBase
{
    /// <summary>
    /// Contains entity core context logic
    /// </summary>
    public class EntityContext : DbContext
    {
        private readonly ILoggerFactory MyConsoleLoggerFactory;

        /// <summary>
        /// The central_processing_unit
        /// in database context
        /// </summary>
        public DbSet<CpuEntity> CpuEntityContext { get; set; }

        /// <summary>
        /// The constructor to allow logging
        /// sql queries
        /// </summary>
        public EntityContext()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder
                        .AddConsole()
                        .AddFilter
                        (DbLoggerCategory.Database.Command.Name, LogLevel.Information));

            MyConsoleLoggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }

        /// <summary>
        /// Contains logic to log sql querries with
        /// sensitive data and configures connection with Sql server
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory).EnableSensitiveDataLogging(true).UseSqlServer("Connection string");

        }

    }
}
