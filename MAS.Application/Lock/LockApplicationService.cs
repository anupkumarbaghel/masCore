
using MAS.Core.Interface.Application.Lock;
using MAS.Core.Interface.Repository.Lock;



namespace MAS.Application.Lock
{
    public class LockApplicationService :MAS.Core.Interface.Application.Lock.ILockApplicationService
    {
        ILockRepositoryService _LockRepositoryService;
        public LockApplicationService(ILockRepositoryService lockRepositoryService)
        {
            _LockRepositoryService = lockRepositoryService;
        }

        

        Core.Domain.Admin.Admin ILockApplicationService.VerifyKey(string key)
        {
            return _LockRepositoryService.VerifyKey(key);
        }

        Core.Domain.Store.Store ILockApplicationService.VerifyStoreKey(string key)
        {
            return _LockRepositoryService.VerifyStoreKey(key);
        }
    }
}
