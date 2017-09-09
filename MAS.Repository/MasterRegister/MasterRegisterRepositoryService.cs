using MAS.Core.Interface.Repository.MasterRegister;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MAS.Core.Domain.Store.MasterRegister;
using System;
using System.Collections.Generic;
using MAS.Core.DTO;

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

        public List<DTOOpeningBalance> GetOpeningBalance(int StoreID, DateTime? LastDate)
        {
            if (LastDate == null) LastDate = DateTime.Now.AddYears(-100);
            return _context.DTOOpeningBalances
                .FromSql("[dbo].[usp_GetOpeningBalance] @p0, @p1",
                    StoreID,LastDate)
              .ToList();
        }

        
    }
}
