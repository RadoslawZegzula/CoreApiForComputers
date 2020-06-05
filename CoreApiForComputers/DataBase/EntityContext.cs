using CoreApiForComputers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreApiForComputers.DataBase
{
    public class EntityContext : DbContext
    {
        private readonly ILoggerFactory MyConsoleLoggerFactory;
        public DbSet<CpuEntity> CpuEntityContext { get; set; }

        public EntityContext()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder
                        .AddConsole()
                        .AddFilter
                        (DbLoggerCategory.Database.Command.Name, LogLevel.Information));

            MyConsoleLoggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory).EnableSensitiveDataLogging(true).UseSqlServer("Connection string");

        }

    }
}
