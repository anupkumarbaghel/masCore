using MAS.Core.Interface.Application.MasterRegister;
using MAS.Core.Interface.Repository.MasterRegister;
using System;
using System.Collections.Generic;

namespace MAS.Application.MasterRegister
{
    public class MasterRegisterApplicationService : IMasterRegisterApplicationService
    {
        IMasterRegisterRepositoryService _masterRegisterRepositoryService;
        public MasterRegisterApplicationService(IMasterRegisterRepositoryService masterRegisterRepositoryService)
        {
            _masterRegisterRepositoryService = masterRegisterRepositoryService;
        }

        public Core.Domain.Store.MasterRegister.MasterRegister CreateMasterRegister(Core.Domain.Store.MasterRegister.MasterRegister masterRegister)
        {
            return _masterRegisterRepositoryService.CreateMasterRegister(masterRegister);
        }

        public List<Core.Domain.Store.MasterRegister.MasterRegister> GetAllMasterRegisterOfStore(int storeID)
        {
            return _masterRegisterRepositoryService.GetAllMasterRegisterOfStore(storeID);
        }
    }
}
