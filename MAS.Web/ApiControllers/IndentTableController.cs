using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.Indent;
using MAS.Core.Domain.Indent;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/IndentTable")]
    public class IndentTableController : Controller
    {
        private readonly IIndentTableAppService _IndentTableAppService;
        public IndentTableController(IIndentTableAppService indentTableAppService)
        {
            _IndentTableAppService = indentTableAppService;
        }

        [HttpGet]
        public IActionResult GetAllIndentTable()
        {
            return Ok(_IndentTableAppService.GetAllIndentTable());
        }

        [HttpGet("{id}")]
        public IActionResult GetIndentTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var indent = _IndentTableAppService.GetIndentTable(id);

            if (indent == null)
            {
                return NotFound();
            }

            return Ok(indent);
        }

        [HttpPost]
        public IActionResult PostIndentTable([FromBody] IndentTable indentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           long ID =  _IndentTableAppService.CreateIndentTable(indentTable);

            return Ok(ID);
        }

        [HttpPut("{id}")]
        public IActionResult PutIndentTable([FromRoute] int id, [FromBody] IndentTable indentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indentTable.ID)
            {
                return BadRequest();
            }

            _IndentTableAppService.UpdateIndentTable(indentTable);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIndentTable([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           return Ok(_IndentTableAppService.DeleteIndentTable(id)) ;
            
        }




    }
}