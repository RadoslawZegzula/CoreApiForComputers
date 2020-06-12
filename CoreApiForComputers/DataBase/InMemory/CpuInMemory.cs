using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase.InMemory
{
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

        public List<CpuEntity> ReturnCpus()
        {
            return cpus;
        }
    }

}
