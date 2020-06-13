using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase.InMemory
{
    /// <summary>
    /// Stores central_processing_units
    /// in a memory
    /// </summary>
    public class CpuInMemory
    {
        private static readonly List<CpuEntity> cpus;

        static CpuInMemory()
        {
            cpus = new List<CpuEntity>()
            {
            new CpuEntity()
            {
                Id = 1,
                Cores = 1
            },
            new CpuEntity()
            {
                Id = 2,
                Cores = 22
            },
            new CpuEntity()
            {
                Id = 3,
                Cores = 333
            },
            };
        }

        /// <summary>
        /// Returns a collection
        /// </summary>
        /// <returns>The central_processing_units </returns>
        public List<CpuEntity> ReturnCpus()
        {
            return cpus;
        }
    }

}
