using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityInterfaces
{
    /// <summary>
    /// Generic repository interface with Create, Read, Update, Delete declarations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository <TEntity> where TEntity : BaseEntityOfParts
    {
        /// <summary>
        /// Creates one new entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Create<T>(TEntity entity);

        /// <summary>
        /// Returns entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> Read<T>();

        /// <summary>
        /// Returns one entity by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Read<T>(int id);

        /// <summary>
        /// Returns filtered entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Read<T>(BasePartFiltringParameters parameters);

        /// <summary>
        /// Updates one entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityForUpdate"></param>
        public void Update<T>(TEntity entityForUpdate);

        /// <summary>
        /// Deletes one entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityForDeletion"></param>
        public void Delete<T>(TEntity entityForDeletion);

    }
}
