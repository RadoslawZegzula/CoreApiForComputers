using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    /// <summary>
    /// Contains logic for repository in entity core
    /// </summary>
    public class EntityGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntityOfParts
    {
        private readonly EntityCoreContext context;
        private readonly DbSet<TEntity> dbSet;

        /// <summary>
        /// The constructor that implements
        /// generic repository pattern
        /// </summary>
        /// <param name="context"></param>
        public EntityGenericRepository(EntityCoreContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Create<T>(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Read<T>()
        {
            return dbSet.ToList();
        }

        public TEntity Read<T>(int id)
        {
            return dbSet.Find(id);
        }

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

        public void Update<T>(TEntity entityForUpdate)
        {
            dbSet.Attach(entityForUpdate);
            context.Entry(entityForUpdate).State = EntityState.Modified;

            context.SaveChanges();
        }

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
