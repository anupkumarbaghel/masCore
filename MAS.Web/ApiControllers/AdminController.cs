using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.Admin;
using MAS.Core.Domain.Admin;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly IAdminApplicationService _AdminService;
        public AdminController(IAdminApplicationService adminService)
        {
            _AdminService = adminService;
        }

        [HttpPost]
        public IActionResult PostKeyForVerification([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           Admin submittedAdmin = _AdminService.PostAdmin(admin);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(submittedAdmin);
        }

        



    }
}