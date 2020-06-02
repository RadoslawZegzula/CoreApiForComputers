using CoreApiForComputers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; //<-- part of the new logging implementation
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
