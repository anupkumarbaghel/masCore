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
    [Route("api/Indent")]
    public class IndentController : Controller
    {
        private readonly IIendentService _IndentService;
        public IndentController(IIendentService indentService)
        {
            _IndentService = indentService ;
        }

        [HttpGet]
        public IEnumerable<Indent> GetAllIndent()
        {
            return  _IndentService.GetAllIndent();
        }

        [HttpGet("{id}")]
        public IActionResult GetIndent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var indent = _IndentService.GetIndent(id);

            if (indent == null)
            {
                return NotFound();
            }

            return Ok(indent);
        }
        
        [HttpGet("bystatus")]
        public IActionResult GetIndentByStatus([FromQuery] string IndentStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var indent = _IndentService.GetIndentByStatus(IndentStatus);

            if (indent == null)
            {
                return NotFound();
            }

            return Ok(indent);
        }

        [HttpPost]
        public IActionResult PostIndent([FromBody] Indent indent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           long ID =  _IndentService.CreateIndent(indent);

            return Ok(ID);
        }

        [HttpPut("{id}")]
        public IActionResult PutIndent([FromRoute] int id, [FromBody] Indent indent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indent.ID)
            {
                return BadRequest();
            }

            _IndentService.UpdateIndent(indent);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIndent([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok( _IndentService.DeleteIndent(id)) ;
            
        }




    }
}