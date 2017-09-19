using System.Collections.Generic;


namespace MAS.Core.Interface.Application.MasterRegister
{
    public interface IMasterRegisterApplicationService
    {
        List<MAS.Core.Domain.Store.MasterRegister.MasterRegister> GetAllMasterRegisterOfStore(int storeID);
        MAS.Core.Domain.Store.MasterRegister.MasterRegister CreateMasterRegister(MAS.Core.Domain.Store.MasterRegister.MasterRegister masterRegister);
        int DeleteMasterRegister(int ID);
    }
}
