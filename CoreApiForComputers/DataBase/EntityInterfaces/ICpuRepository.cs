using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityInterfaces
{
    public interface ICpuRepository
    {
        public void Create(CpuEntity part);
        public IEnumerable<CpuEntity> Read();
        public CpuEntity ReadById(int id);
        public void Update();
        public void Delete();


    }
}
