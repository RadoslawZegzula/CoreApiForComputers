using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.DataBase.InMemory;
using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    /// <summary>
    /// Contains logic for in memory repository implementation
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MemoryGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntityOfParts
    {

        private readonly List<TEntity> entities;

        /// <summary>
        /// Constructs list of entities based on TEntity type
        /// </summary>
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

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Create<T>(TEntity entity)
        {
            entities.Add(entity);
        }

        /// <summary>
        /// Returns entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> Read<T>()
        {
            return entities;
        }

        /// <summary>
        /// Returns entity that has specific id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Read<T>(int id)
        {
            return entities.First(e => e.Id == id);
        }

        /// <summary>
        /// Returns filtered entities 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityForUpdate"></param>
        public void Update<T>(TEntity entityForUpdate)
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityForUpdate.Id);
            entities.Remove(entity);
            entities.Add(entityForUpdate);
        }

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityForDeletion"></param>
        public void Delete<T>(TEntity entityForDeletion)
        {
            var entity = entities.FirstOrDefault(e => e.Id == entityForDeletion.Id);
            entities.Remove(entity);
        }
    }
}
