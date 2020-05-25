using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.DataBase
{
    public interface IDatabaseAcces
    {
        public void Create();
        public IEnumerable<T> Read<T>();
        public void Update();
        public void Delete <T>();


    }
}
