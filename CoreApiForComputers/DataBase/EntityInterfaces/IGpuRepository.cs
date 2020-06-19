using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityInterfaces
{
    public interface IGpuRepository
    {
        public void Create(GpuEntity part);
        public IEnumerable<GpuEntity> Read();
        public GpuEntity ReadById(int id);
        public void Update();
        public void Delete();
    }
}
