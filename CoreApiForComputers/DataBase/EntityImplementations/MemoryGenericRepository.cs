using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    public class MemoryGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntityOfParts
    {
        //private static readonly List<CpuEntity> cpus = new CpuInMemory().ReturnCpus();
        private readonly List<TEntity> entities;

        public MemoryGenericRepository()
        {
            var typeOfEntity = typeof(TEntity);

            if (typeOfEntity == typeof(CpuEntity))
            {
                entities = CpuInMemory.ReturnCpus() as List<TEntity>;
            }
            if (typeOfEntity == typeof(GpuEntity))
            {
                entities = GpuInMemory.ReturnGpus() as List<TEntity>;
            }

        }

        public void Create<T>(TEntity entity)
        {
            entities.Add(entity);
        }

        public IEnumerable<TEntity> Read<T>()
        {
            return entities;
        }

        public TEntity Read<T>(int id)
        {
            return entities.First(e => e.Id == id);
        }

        public IEnumerable<TEntity> Read<T>(BasePartFiltringParameters parameters)
        {
            var cpuCollection = entities as IEnumerable<TEntity>;
        
            if(parameters.MinPrice.HasValue)
            {
                cpuCollection = cpuCollection.Where(c => c.Price >= parameters.MinPrice);
            }
            if (parameters.MaxPrice.HasValue)
            {
                cpuCollection = cpuCollection.Where(c => c.Price <= parameters.MaxPrice);
            }
        
            return cpuCollection.ToList();
        }

        public void Update<T>(TEntity entityForUpdate)
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityForUpdate.Id);
            entities.Remove(entity);
            entities.Add(entityForUpdate);
        }

        public void Delete<T>(TEntity entityForDeletion)
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityForDeletion.Id);
            entities.Remove(entity);
        }
    }
}
