using MAS.Core.Domain.Store.MasterRegister;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MAS.Core.Domain.Store.Indent;
using MAS.Core.Domain.Store.MeasurementBook;
using MAS.Core.DTO;

namespace MAS.Core.Interface.ExcelReport
{
    public interface IGenerateExcelReport
    {
        MemoryStream GenerateExcelMASReport(List<MasterRegister> masterRegister, IEnumerable<Indent> indents, IEnumerable<MeasurementBook> mbs, DTOExcelReportInput dTOExcelReportInput, List<DTO.DTOOpeningBalance> openingBalances);
        MemoryStream GenerateExcelBalanceQuantityReport(List<MAS.Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt, DTOExcelReportInput dTOExcelReportInput);
        MemoryStream GenerateExcelAmountBalanceQuantityReport(List<MAS.Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt, DTOExcelReportInput dTOExcelReportInput);
        
    }
}
