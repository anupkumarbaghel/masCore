using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.MasterRegister
{
    public interface IMasterRegisterRepositoryService
    {
        List<MAS.Core.Domain.Store.MasterRegister.MasterRegister> GetAllMasterRegisterOfStore(int storeID);
        MAS.Core.Domain.Store.MasterRegister.MasterRegister CreateMasterRegister(MAS.Core.Domain.Store.MasterRegister.MasterRegister masterRegister);
        List<MAS.Core.DTO.DTOOpeningBalance> GetOpeningBalance(int StoreID, DateTime? LastDate);
        int DeleteMasterRegister(int ID);
    }
}
