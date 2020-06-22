using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    public class GpuEntityRepository : IGpuRepository
    {
        private static readonly EntityCoreContext _context = new EntityCoreContext();

        public void Create(GpuEntity part)
        {
            throw new NotImplementedException();
        }

        public GpuEntity Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<GpuEntity> Read()
        {
            return _context.GpuEntityContext;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
