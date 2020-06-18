using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    public class CpuMemoryRepository : ICpuRepository
    {
        private static readonly List<CpuEntity> cpus = new CpuInMemory().ReturnCpus();

        public void Create(CpuEntity part)
        {
            cpus.Add(part);
        }

        public IEnumerable<CpuEntity> Read()
        {
            return cpus;
        }

        public CpuEntity ReadById(int id)
        {
            var cpuEntity = cpus.Where(c => c.Id == id).First();
            return cpuEntity;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
