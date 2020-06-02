using CoreApiForComputers.DataBase.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase
{
    public class MemoryRepository : IRepository
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read<T>()
        {
            var cpuEntities = (IEnumerable<T>) new CpuInMemory().ReturnCpus();

            return cpuEntities;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
