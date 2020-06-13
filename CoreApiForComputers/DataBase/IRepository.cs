using System.Collections.Generic;

namespace CoreApiForComputers.DataBase
{
    public interface IRepository
    {
        public void Create<T>(T part);
        public IEnumerable<T> Read<T>();
        public IEnumerable<T> ReadById<T>(int id);
        public void Update();
        public void Delete <T>();


    }
}
