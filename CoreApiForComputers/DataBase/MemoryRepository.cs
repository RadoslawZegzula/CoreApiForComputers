using CoreApiForComputers.Controllers;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase
{
    public class MemoryRepository : IRepository
    {
        private readonly List<CpuEntity> cpus;
        public MemoryRepository()
        {
            cpus = new CpuInMemory().ReturnCpus();
        }

        public void Create<T>(T part)
        {
            if(part is CpuEntity)
            {
                cpus.Add(part as CpuEntity);
            }
        }

        public void Delete<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read<T>()
        {
            return (IEnumerable<T>) cpus;
        }

        public IEnumerable<T> ReadById<T>(int id)
        {
            var cpuEntity = cpus.Where(c => c.Id == id);
            return (IEnumerable<T>) cpuEntity;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
