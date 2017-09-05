using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MAS.Core.Domain.ExcelReport;

namespace MAS.Core.Interface.Application.ExcelReport
{
    public interface IGenerateExcelReportApplication
    {
        MemoryStream GenerateExcelReport(ExcelReportInputModel excelReportInputModel);
    }
}
