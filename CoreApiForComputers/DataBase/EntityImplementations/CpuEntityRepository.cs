﻿using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public CpuEntity Read(int cpuId)
        {
            return _context.CpuEntityContext.FirstOrDefault(c => c.Id == cpuId);
        }

        public void Update(int cpuId, CpuEntity cpuForCreation)
        {
            _context.CpuEntityContext.Update(cpuForCreation);
            _context.SaveChanges();
        }
        public void Delete(CpuEntity cpuForDeletion)
        {
            _context.CpuEntityContext.Remove(cpuForDeletion);
            _context.SaveChanges();
        }

    }
}
