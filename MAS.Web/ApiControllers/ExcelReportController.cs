using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Interface.Application.ExcelReport;
using MAS.Core.DTO;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MAS.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/excelreport")]
    public class ExcelReportController : Controller
    {
        private readonly IGenerateExcelReportApplication _excelReport;
        private readonly IHostingEnvironment _env;
        public ExcelReportController(IGenerateExcelReportApplication excelReport, IHostingEnvironment env)
        {
            _excelReport = excelReport;
            _env = env;
        }
        [HttpGet]
        public IActionResult GetYourQuestion()
        {
           
            return Ok("what is your name");
        }
        [HttpPost]
        public IActionResult PostGenerateExcelReport([FromBody] DTOExcelReportInput excelReportInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MemoryStream msExcelReport = _excelReport.GenerateExcelReport(excelReportInput);

            string sWebRootFolder = _env.WebRootPath;
            string pathFileName = @"report/" + excelReportInput.StoreName;
            string fileName = @"MAS Account.xlsx";
            string conbinedPath = Path.Combine(pathFileName, fileName);
            string reportURL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, conbinedPath);
            string filePath = Path.Combine(sWebRootFolder, conbinedPath);
            string directoryfile = Path.Combine(sWebRootFolder, pathFileName);
            System.IO.Directory.CreateDirectory(directoryfile);


            using (var file = System.IO.File.Open(filePath, FileMode.Create))
            {
                msExcelReport.Position = 0; // reset the position of the memory stream
                msExcelReport.CopyTo(file); // copy the memory stream to the file stream
            }
            msExcelReport.Dispose();

            excelReportInput.ReportUrl = reportURL;
            return Ok(excelReportInput);
        }

        



    }
}