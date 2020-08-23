using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    /// <summary>
    /// Contains logic for entity core repository implementation
    /// </summary>
    public class EntityGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntityOfParts
    {
        private readonly EntityCoreContext context;
        private readonly DbSet<TEntity> dbSet;

        /// <summary>
        /// Constructs database context and dbSet
        /// based on entity type
        /// </summary>
        /// <param name="context"></param>
        public EntityGenericRepository(EntityCoreContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Creates entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Create<T>(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Returns entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> Read<T>()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Returns entity that has specific id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Read<T>(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Returns filtered entities by filtring parametrs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Read<T>(BasePartFiltringParameters parameters)
        {
            var cpuCollection = dbSet as IQueryable<TEntity>;

            if (parameters.MinPrice.HasValue)
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
            dbSet.Attach(entityForUpdate);
            context.Entry(entityForUpdate).State = EntityState.Modified;

            context.SaveChanges();
        }

        /// <summary>
        /// Deletes specific entity 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityForDeletion"></param>
        public void Delete<T>(TEntity entityForDeletion)
        {
            if (context.Entry(entityForDeletion).State == EntityState.Detached)
            {
                dbSet.Attach(entityForDeletion);
            }
            dbSet.Remove(entityForDeletion);
            context.SaveChanges();
        }
      
    }
}
