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

            MemoryStream msExcelReport = new MemoryStream();
            string fileName = string.Empty;

            switch (excelReportInput.ReportType)
            {
                case "mas":
                    msExcelReport = _excelReport.GenerateExcelReport(excelReportInput);
                    fileName = fileOfMasAccountName(excelReportInput);
                    break;
                case "bq":
                    msExcelReport = _excelReport.GenerateExcelBalanceQuantityReport(excelReportInput);
                    fileName="Balance Quantity of "+excelReportInput.StoreName+" "+ Convert.ToDateTime(excelReportInput.StartDate).ToString("dd.MM.yyyy") + ".xlsx"; ;
                    break;
                case "abq":
                    msExcelReport = _excelReport.GenerateExcelAmountBalanceQuantityReport(excelReportInput);
                    fileName = "Amount Balance Quantity of " + excelReportInput.StoreName + " " + Convert.ToDateTime(excelReportInput.StartDate).ToString("dd.MM.yyyy") + ".xlsx"; ;
                    break;
            }


            string sWebRootFolder = _env.WebRootPath;
            string pathFileName = @"report/" + excelReportInput.StoreName;  
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


        private string fileOfMasAccountName(DTOExcelReportInput excelReportInput)
        {
            string result = string.Empty;
            string startDate = string.Empty, endDate = string.Empty;
            if (excelReportInput.StartDate != null && excelReportInput.EndDate != null)
            {
                startDate = Convert.ToDateTime(excelReportInput.StartDate).ToString("dd.MM.yyyy");
                endDate = Convert.ToDateTime(excelReportInput.EndDate).ToString("dd.MM.yyyy");
            }

            result = @"MAS Account_" + excelReportInput.StoreName + "_" + startDate + "_" + endDate + ".xlsx";

            return result;
        }
    }
}