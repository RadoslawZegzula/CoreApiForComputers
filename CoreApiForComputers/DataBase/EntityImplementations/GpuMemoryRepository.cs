using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    public class GpuMemoryRepository : IGpuRepository
    {
        private static readonly List<GpuEntity> gpus = new GpuInMemory().ReturnGpus();

        public void Create(GpuEntity part)
        {
            gpus.Add(part);
        }

        public IEnumerable<GpuEntity> Read()
        {
            return gpus;
        }

        public GpuEntity Read(int id)
        {
            var gpuEntity = gpus.Where(c => c.Id == id).First();
            return gpuEntity;
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
