using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.EntityImplementations
{
    /// <summary>
    /// Contains logic for repository in entity core
    /// </summary>
    public class CpuEntityRepository : ICpuRepository
    {
        private static readonly EntityCoreContext _context = new EntityCoreContext();

        public void Create(CpuEntity part)
        {
            throw new NotImplementedException();
        }

        public CpuEntity ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CpuEntity> Read()
        {
            return _context.CpuEntityContext;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

    }
}
