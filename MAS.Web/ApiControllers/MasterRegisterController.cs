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
            return Ok(_masterRegister.GetAllMasterRegisterOfStore(stID));
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



    }
}