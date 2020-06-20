using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
            _context.CpuEntityContext.Add(part);
            _context.SaveChanges();
        }
        public IEnumerable<CpuEntity> Read()
        {
            return _context.CpuEntityContext;
        }

        public CpuEntity ReadById(int id)
        {
            return _context.CpuEntityContext.FirstOrDefault(c => c.Id == id);
        }

        public void Update(int cpuId, CpuEntity cpuForCreation)
        {
            _context.CpuEntityContext.Update(cpuForCreation);
            _context.SaveChanges();
        }
        public void Delete(CpuEntity cpuForCreation)
        {
            _context.CpuEntityContext.Remove(cpuForCreation);
            _context.SaveChanges();
        }

    }
}
