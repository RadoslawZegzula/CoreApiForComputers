using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase.InMemory
{
    public class CpuInMemory
    {
        private IEnumerable<CpuEntity> cpus;

        public CpuInMemory()
        {
            cpus = new CpuEntity[]
            {
            new CpuEntity()
            {
                Cores = 1
            },
            new CpuEntity()
            {
                Cores = 22
            },
            new CpuEntity()
            {
                Cores = 333
            },
            };
        }
        public IEnumerable<CpuEntity> ReturnCpus()
        {
            return cpus;
        }
    }

}
