using MAS.Core.Domain.Store.MasterRegister;
using MAS.Core.Interface.Application.MasterRegister;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/masterregister")]
    public class MasterRegisterController : Controller
    {
        private readonly IMasterRegisterApplicationService _masterRegister;
        public MasterRegisterController(IMasterRegisterApplicationService masterRegister)
        {
            _masterRegister = masterRegister;
        }

        [HttpGet]
        public IActionResult GetAllMasterRegisterOfStore(string storeID)
        {
            int stID = int.Parse(storeID);
            var masterRegisters = _masterRegister.GetAllMasterRegisterOfStore(stID);

            MAS.Core.ViewModel.MasterRegisterExtension masterSelectOption = new MAS.Core.ViewModel.MasterRegisterExtension
            {
                ID=0, MaterialNameWithDescription="Please Select", StoreID=stID
            };
            masterRegisters.Insert(0, masterSelectOption);

            return Ok(masterRegisters);
        }

        [HttpPost]
        public IActionResult PostMasterRegister([FromBody] MasterRegister masterRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_masterRegister.CreateMasterRegister(masterRegister));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMasterRegister([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_masterRegister.DeleteMasterRegister(id));

        }



    }
}