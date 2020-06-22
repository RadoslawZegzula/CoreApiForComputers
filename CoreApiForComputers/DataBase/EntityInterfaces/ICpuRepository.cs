using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityInterfaces
{
    public interface ICpuRepository
    {
        public void Create(CpuEntity part);
        public IEnumerable<CpuEntity> Read();
        public CpuEntity Read(int cpuId);
        public void Update(int cpuId, CpuEntity cpuForCreation);
        public void Delete(CpuEntity cpuForDeletion);

    }
}
