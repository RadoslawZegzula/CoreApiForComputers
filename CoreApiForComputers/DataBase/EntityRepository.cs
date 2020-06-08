using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase
{
    public class EntityRepository : IRepository
    {
        private static readonly EntityContext _context = new EntityContext();

        public void Create<T>(T part)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read<T>()
        {
            return (IEnumerable<T>) _context.CpuEntityContext;
        }

        public IEnumerable<T> ReadById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
