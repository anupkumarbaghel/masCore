using MAS.Core.Interface.Repository.Lock;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MAS.Repository.Lock
{
    public class LockRepositoryService:Core.Interface.Repository.Lock.ILockRepositoryService
    {
        MASDBContext _context;
        public LockRepositoryService(MASDBContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

      

        Core.Domain.Admin.Admin ILockRepositoryService.VerifyKey(string key)
        {
            return _context.Admins.Include(e => e.StoreCollection).FirstOrDefault(e => e.Key == key);
        }

        Core.Domain.Store.Store ILockRepositoryService.VerifyStoreKey(string key)
        {
            return _context.Stores.FirstOrDefault(e => e.Key == key);
        }

    }
}
