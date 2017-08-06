using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Lock
{
    public interface ILockRepositoryService
    {
        Domain.Admin.Admin VerifyKey(string key);
        Domain.Store.Store VerifyStoreKey(string key);
    }
}
