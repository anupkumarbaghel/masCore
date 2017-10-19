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
            _context.Database.ExecuteSqlCommand("[dbo].[usp_UpdateSerialNumberByOne] @p0,@p1,@P2", masterRegister.SerialNumber, masterRegister.StoreID,masterRegister.ID);

            if (masterRegister.ID > 0)
            {
                _context.Update(masterRegister);
            }
            else
            {
                _context.Add(masterRegister);
            }

            _context.SaveChanges();
            return masterRegister;
        }

        public int DeleteMasterRegister(int ID)
        {
            Core.Domain.Store.MasterRegister.MasterRegister masterRegister = _context.MasterRegisters.SingleOrDefault(e => e.ID == ID);
            if (masterRegister == null) return -1;
            masterRegister.SerialNumber = -1;

            _context.Database.ExecuteSqlCommand("[dbo].[usp_UpdateSerialNumberByOne] @p0,@p1,@P2", masterRegister.SerialNumber, masterRegister.StoreID, masterRegister.ID);

            _context.MasterRegisters.Remove(masterRegister);
            _context.SaveChanges();
            return masterRegister.ID;
        }

        public List<Core.Domain.Store.MasterRegister.MasterRegister> GetAllMasterRegisterOfStore(int storeID)
        {
            return _context.MasterRegisters.Where(e => e.StoreID == storeID).OrderBy(e=>e.SerialNumber).ToList();
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
