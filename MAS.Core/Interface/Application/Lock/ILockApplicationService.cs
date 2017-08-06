using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Application.Lock
{
    public interface ILockApplicationService
    {
        Domain.Admin.Admin VerifyKey(string key);
        Domain.Store.Store VerifyStoreKey(string key);
    }
}
