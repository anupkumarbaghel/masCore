using System;
using System.Collections.Generic;


namespace MAS.Core.Interface.Application.MasterRegister
{
    public interface IMasterRegisterApplicationService
    {
        List<MAS.Core.ViewModel.MasterRegisterExtension> GetAllMasterRegisterOfStore(int storeID,DateTime date);
        MAS.Core.Domain.Store.MasterRegister.MasterRegister CreateMasterRegister(MAS.Core.Domain.Store.MasterRegister.MasterRegister masterRegister);
        int DeleteMasterRegister(int ID);
    }
}
