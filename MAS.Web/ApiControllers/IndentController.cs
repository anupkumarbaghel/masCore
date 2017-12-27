using MAS.Core.Domain.Store.Indent;
using MAS.Core.Interface.Application.Indent;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Indent")]
    public class IndentController : Controller
    {
        private readonly IIendentService _IndentService;
        public IndentController(IIendentService indentService)
        {
            _IndentService = indentService;
        }

        [HttpGet]
        public IActionResult GetAllIndentByStatus(string indentStatus,string storeID,bool isSitework)
        {
            int stID = int.Parse(storeID);
            return Ok(_IndentService.GetAllIndentByStatus(indentStatus, stID,isSitework));
        }

        [HttpGet("{id}")]
        public IActionResult GetIndent([FromRoute] long id)
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

        [HttpGet("openindent")]
        public IActionResult GetOpenIndent(string storeID, bool isSitework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int stID = int.Parse(storeID);
            var indent = _IndentService.GetOpenIndent(stID,isSitework);

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
            return Ok(_IndentService.CreateEditIndent(indent));
        }

        [HttpPost("draftopen")]
        public IActionResult PostDraftOpen([FromBody] Indent indent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _IndentService.DraftOpenIndent(indent);

            return Ok();
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