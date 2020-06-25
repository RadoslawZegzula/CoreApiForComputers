using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.FiltringParameters;
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

        public CpuEntity Read(int id)
        {
            var cpuEntity = cpus.Where(c => c.Id == id).First();
            return cpuEntity;
        }

        public IEnumerable<CpuEntity> Read(BasePartFiltringParameters parameters)
        {

            var cpuCollection = cpus as IEnumerable<CpuEntity>;

            if(parameters.MinPrice.HasValue)
            {
                cpuCollection = cpuCollection.Where(c => c.Price >= parameters.MinPrice);
            }
            if (parameters.MaxPrice.HasValue)
            {
                cpuCollection = cpuCollection.Where(c => c.Price <= parameters.MaxPrice);
            }

            return cpuCollection;
        }

        public void Update(int cpuId, CpuEntity cpuForCreation)
        { 
            cpus.Remove(Read(cpuId));
            cpus.Add(cpuForCreation);
        }

        public void Delete(CpuEntity cpuForDeletion)
        {
            cpus.Remove(Read(cpuForDeletion.Id));
        }
    }
}
