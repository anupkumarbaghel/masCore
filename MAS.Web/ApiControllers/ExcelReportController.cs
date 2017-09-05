using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.ExcelReport;
using MAS.Core.Domain.ExcelReport;
using System.IO;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/excelreport")]
    public class ExcelReportController : Controller
    {
        private readonly IGenerateExcelReportApplication _excelReport;
        public ExcelReportController(IGenerateExcelReportApplication excelReport)
        {
            _excelReport = excelReport;
        }

        [HttpPost]
        public IActionResult PostGenerateExcelReport([FromBody] ExcelReportInputModel excelReportInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MemoryStream msExcelReport = _excelReport.GenerateExcelReport(excelReportInput);

            using (var file = System.IO.File.Open( "MAS Report.xlsx", FileMode.Create))
            {
                msExcelReport.Position = 0; // reset the position of the memory stream
                msExcelReport.CopyTo(file); // copy the memory stream to the file stream
            }
            msExcelReport.Dispose();
           

            return Ok();
        }

        



    }
}