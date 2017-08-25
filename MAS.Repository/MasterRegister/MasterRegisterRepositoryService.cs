using MAS.Core.Interface.Repository.MasterRegister;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MAS.Core.Domain.Store.MasterRegister;
using System;
using System.Collections.Generic;

namespace MAS.Repository.MasterRegister
{
    public class MasterRegisterRepositoryService:IMasterRegisterRepositoryService
    {
        MASDBContext _context;
        public MasterRegisterRepositoryService(MASDBContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Core.Domain.Store.MasterRegister.MasterRegister CreateMasterRegister(Core.Domain.Store.MasterRegister.MasterRegister masterRegister)
        {
            _context.Add(masterRegister);
            _context.SaveChanges();
            return masterRegister;
        }

        public List<Core.Domain.Store.MasterRegister.MasterRegister> GetAllMasterRegisterOfStore(int storeID)
        {
            return _context.MasterRegisters.Where(e => e.StoreID == storeID).ToList();
        }
    }
}
