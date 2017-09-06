using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MAS.Core.DTO;

namespace MAS.Core.Interface.Application.ExcelReport
{
    public interface IGenerateExcelReportApplication
    {
        MemoryStream GenerateExcelReport(DTOExcelReportInput excelReportInputModel);
    }
}
