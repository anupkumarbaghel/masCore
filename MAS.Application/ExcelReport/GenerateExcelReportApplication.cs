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
using MAS.Core.Interface.Application.MasterRegister;

namespace MAS.Application.ExcelReport
{
    public class GenerateExcelReportApplication : IGenerateExcelReportApplication
    {
        IGenerateExcelReport _generateExcelReport;
        IMasterRegisterRepositoryService _masterRegisterRepositoryService;
        IIendentRepositoryService _indentService;
        IMeasurementBookRepositoryService _measurementBookService;
        IMasterRegisterApplicationService _masterRegisterApplication;

        public GenerateExcelReportApplication(IGenerateExcelReport generateExcelReport
            , IMasterRegisterRepositoryService masterRegisterRepositoryService
            , IIendentRepositoryService indentService
            , IMeasurementBookRepositoryService measurementBookService
            , IMasterRegisterApplicationService masterRegister)
        {
            _generateExcelReport = generateExcelReport;
            _masterRegisterRepositoryService = masterRegisterRepositoryService;
            _indentService = indentService;
            _measurementBookService = measurementBookService;
            _masterRegisterApplication = masterRegister;
        }
        public MemoryStream GenerateExcelReport(DTOExcelReportInput excelReportInputModel)
        {
            var masterRegisters =  _masterRegisterRepositoryService.GetAllMasterRegisterOfStore(excelReportInputModel.StoreID);
            var indents = _indentService.GetAllIndentExcelReport(excelReportInputModel);
            var mbs = _measurementBookService.GetAllMeasurementForExcelReport(excelReportInputModel);
            List<DTOOpeningBalance> openigBalances = _masterRegisterRepositoryService.GetOpeningBalance(excelReportInputModel.StoreID, excelReportInputModel.StartDate);
            return _generateExcelReport.GenerateExcelMASReport(masterRegisters,indents,mbs, excelReportInputModel, openigBalances);
        }
        public MemoryStream GenerateExcelBalanceQuantityReport(DTOExcelReportInput excelReportInputModel)
        {
            List<MAS.Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt = 
                _masterRegisterApplication.GetAllMasterRegisterOfStore(excelReportInputModel.StoreID
                , Convert.ToDateTime(excelReportInputModel.StartDate));
            return _generateExcelReport.GenerateExcelBalanceQuantityReport(listMasterRegisterExt, excelReportInputModel);
        }
        public MemoryStream GenerateExcelAmountBalanceQuantityReport(DTOExcelReportInput excelReportInputModel)
        {
            List<MAS.Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt =
                _masterRegisterApplication.GetAllMasterRegisterOfStore(excelReportInputModel.StoreID
                , Convert.ToDateTime(excelReportInputModel.StartDate));
            return _generateExcelReport.GenerateExcelAmountBalanceQuantityReport(listMasterRegisterExt, excelReportInputModel);
        }

    }
}
