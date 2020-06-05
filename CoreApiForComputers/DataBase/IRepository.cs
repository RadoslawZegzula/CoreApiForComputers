using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase
{
    public interface IRepository
    {
        public void Create();
        public IEnumerable<T> Read<T>();
        public IEnumerable<T> ReadById<T>(int id);
        public void Update();
        public void Delete <T>();


    }
}
