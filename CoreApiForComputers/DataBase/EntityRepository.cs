using System;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase
{
    /// <summary>
    /// Contains logic for repository in entity core
    /// </summary>
    public class EntityRepository : IRepository
    {
        private static readonly EntityContext _context = new EntityContext();

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="part"></param>
        public void Create<T>(T part)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Delete<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection IEnumrable of objects</returns>
        public IEnumerable<T> Read<T>()
        {
            return (IEnumerable<T>) _context.CpuEntityContext;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadById<T>(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
