using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.Lock;
using MAS.Core.Domain.Admin;
using MAS.Core.Domain.Store;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/lock")]
    public class LockController : Controller
    {
        private readonly ILockApplicationService _LockService;
        public LockController(ILockApplicationService lockService)
        {
            _LockService = lockService;
        }

        [HttpPost("admin")]
        public IActionResult PostKeyForVerification([FromBody] Admin adminKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           Admin admin =  _LockService.VerifyKey(adminKey.Key);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpPost("store")]
        public IActionResult PostStoreKeyForVerification([FromBody] Store storeKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Store admin = _LockService.VerifyStoreKey(storeKey.Key);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }





    }
}