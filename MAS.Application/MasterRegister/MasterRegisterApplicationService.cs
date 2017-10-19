using MAS.Core.DTO;
using MAS.Core.Interface.Application.MasterRegister;
using MAS.Core.Interface.Repository.MasterRegister;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public int DeleteMasterRegister(int ID)
        {
            return _masterRegisterRepositoryService.DeleteMasterRegister(ID);
        }

        public List<MAS.Core.ViewModel.MasterRegisterExtension> GetAllMasterRegisterOfStore(int storeID,DateTime date)
        {
            List<MAS.Core.ViewModel.MasterRegisterExtension> listMasterRegister = new List<Core.ViewModel.MasterRegisterExtension>();
            var masterRegisters=_masterRegisterRepositoryService.GetAllMasterRegisterOfStore(storeID);
            List<DTOOpeningBalance> openigBalances = _masterRegisterRepositoryService.GetOpeningBalance(storeID, date);
            foreach (var mr in masterRegisters)
            {
                MAS.Core.ViewModel.MasterRegisterExtension mre = new Core.ViewModel.MasterRegisterExtension();
                mre.ID = mr.ID;
                mre.SerialNumber = mr.SerialNumber;
                mre.MaterialNameWithDescription = mr.MaterialNameWithDescription;
                mre.MaterialUnit = mr.MaterialUnit;
                mre.MaterialRate = mr.MaterialRate;
                mre.Quantity = openigBalances.Where(e => e.ID == mr.ID).Select(e => e.OpeningBalance).FirstOrDefault();
                listMasterRegister.Add(mre);
            }
            return listMasterRegister;
        }
    }
}
