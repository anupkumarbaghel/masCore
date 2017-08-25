using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.MeasurementBook;
using MAS.Core.Domain.Store.MeasurementBook;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/measurementbook")]
    public class MeasurementBookController : Controller
    {
        private readonly IMeasurementBookApplicationService _MeasuremeantBookService;
        public MeasurementBookController(IMeasurementBookApplicationService measuremeantBookService)
        {
            _MeasuremeantBookService = measuremeantBookService;
        }

        [HttpGet]
        public IActionResult GetAllMeasurementBookByStatus(string measurementBookStatus,string storeID)
        {
            int stID = int.Parse(storeID);
            return Ok(_MeasuremeantBookService.GetAllMeasurementBookByStatus(measurementBookStatus, stID));
        }

        [HttpGet("{id}")]
        public IActionResult GetMeasurementBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mesurementBook = _MeasuremeantBookService.GetMeasurementBook(id);

            if (mesurementBook == null)
            {
                return NotFound();
            }

            return Ok(mesurementBook);
        }

        [HttpGet("openmeasurementbook")]
        public IActionResult GetOpenMeasurementBook(string storeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int stID = int.Parse(storeID);
            var indent = _MeasuremeantBookService.GetOpenMeasurementBook(stID);

            if (indent == null)
            {
                return NotFound();
            }

            return Ok(indent);
        }

        [HttpPost]
        public IActionResult PostCreateEditMeasurementBook([FromBody] MeasurementBook measurementBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_MeasuremeantBookService.CreateEditMeasurementBook(measurementBook));
        }

        [HttpPost("draftopen")]
        public IActionResult PostDraftOpenMeasurementBook([FromBody]  MeasurementBook measurementBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _MeasuremeantBookService.DraftOpenMeasurementBook(measurementBook);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeasurementBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_MeasuremeantBookService.DeleteMeasurementBook(id));

        }



    }
}
