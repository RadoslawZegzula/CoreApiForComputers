using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityInterfaces
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntityOfParts
    {
        public void Create<T>(TEntity entity);
        public IEnumerable<TEntity> Read<T>();
        public TEntity Read<T>(int id);
        public IEnumerable<TEntity> Read<T>(BasePartFiltringParameters parameters);
        public void Update<T>(TEntity entityForUpdate);
        public void Delete<T>(TEntity entityForDeletion);

    }
}
