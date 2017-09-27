using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MAS.Core.Interface.Application.ExcelReport;
using MAS.Core.Domain.Store.MasterRegister;
using MAS.Core.Interface.ExcelReport;
using MAS.Core.Interface.Repository.MasterRegister;
using MAS.Core.DTO;
using MAS.Core.Interface.Repository.Indent;
using MAS.Core.Interface.Repository.MeasurementBook;
using System.Linq;

namespace MAS.Application.ExcelReport
{
    public class GenerateExcelReportApplication : IGenerateExcelReportApplication
    {
        IGenerateExcelReport _generateExcelReport;
        IMasterRegisterRepositoryService _masterRegisterRepositoryService;
        IIendentRepositoryService _indentService;
        IMeasurementBookRepositoryService _measurementBookService;
        public GenerateExcelReportApplication(IGenerateExcelReport generateExcelReport
            , IMasterRegisterRepositoryService masterRegisterRepositoryService
            , IIendentRepositoryService indentService
            , IMeasurementBookRepositoryService measurementBookService)
        {
            _generateExcelReport = generateExcelReport;
            _masterRegisterRepositoryService = masterRegisterRepositoryService;
            _indentService = indentService;
            _measurementBookService = measurementBookService;
        }
        public MemoryStream GenerateExcelReport(DTOExcelReportInput excelReportInputModel)
        {
            var masterRegisters =  _masterRegisterRepositoryService.GetAllMasterRegisterOfStore(excelReportInputModel.StoreID);
            var indents = _indentService.GetAllIndentExcelReport(excelReportInputModel);
            var mbs = _measurementBookService.GetAllMeasurementForExcelReport(excelReportInputModel);
            List<DTOOpeningBalance> openigBalances = _masterRegisterRepositoryService.GetOpeningBalance(excelReportInputModel.StoreID, excelReportInputModel.StartDate);
            return _generateExcelReport.GenerateExcelReport(masterRegisters,indents,mbs, excelReportInputModel, openigBalances);
        }
    }
}
