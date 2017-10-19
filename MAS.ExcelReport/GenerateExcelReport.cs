using MAS.Core.Interface.ExcelReport;
using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Store.MasterRegister;
using OfficeOpenXml;
using System.IO;
using MAS.Core.Domain.Store.Indent;
using MAS.Core.Domain.Store.MeasurementBook;
using System.Linq;
using MAS.Core.DTO;

namespace MAS.ExcelReport
{
    public class GenerateExcelReport : IGenerateExcelReport
    {
        MemoryStream IGenerateExcelReport.GenerateExcelMASReport(List<MasterRegister> masterRegister,IEnumerable<Indent> indents,IEnumerable<MeasurementBook> mbs, DTOExcelReportInput dTOExcelReportInput, List<DTOOpeningBalance> openingBalances)
        {
            ExcelPackage exlPackage = new ExcelPackage();
            ExcelWorksheet MASReport = exlPackage.Workbook.Worksheets.Add("MAS Report");

            MASReport.Column(1).Width = 12;
            MASReport.Column(2).Width = 15;
            MASReport.Column(3).Width = 40;
            MASReport.Column(4).Width = 18;

            MASReport.Row(3).Height = 50;
            MASReport.Row(4).Height = 50;

            int row = 1, col = 1, rowSpan = 0, colSpan = 4;
            string cellValue = storeHeaderName(dTOExcelReportInput);
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 12);

            ///////
            row++; col = 1; rowSpan = 3; colSpan = 0;
            cellValue = "Date of Receipt / Issue";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Indent No. / Date";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Received /Issued";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Head of Account";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            ////
            row = row + rowSpan; col = 1; rowSpan = 0; colSpan = 4;
            cellValue = "Unit";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            ////
            row++; col = 1; rowSpan = 0; colSpan = 4;
            cellValue = "S. No.";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            ////
            row++; col = 1; rowSpan = 0; colSpan = 4;
            cellValue = "Opening Balance";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            ////
            row++; col = 1; rowSpan = 0; colSpan = 4;
            cellValue = "Received during the month";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 11, isBackColorYellow: true);


            ConverterMasterRegisterMASMaterialHeader headerConverter = new ConverterMasterRegisterMASMaterialHeader();
            List<MASMaterialHeader> headers = headerConverter.GenerateHeader(masterRegister,openingBalances);

            MaterialHeaderWriter headerWriter = new MaterialHeaderWriter(headers, MASReport, 5);
            headerWriter.WriteHeader();

           
            DomainToExcelModelConverter domainToExcelConverter = new DomainToExcelModelConverter(indents,mbs);
            List<IndentMBExcelReportModel> ReceivedExcelReportItem = domainToExcelConverter.ReceivedExcelReportItem;
            List<IndentMBExcelReportModel> IssuedExcelReportItem = domainToExcelConverter.IssuedExcelReportItem;
            row = 9; col = 1; rowSpan = 1; colSpan = 1;
            MASModelWriter objMasModelWriter = new MASModelWriter(MASReport
                                                                    , ReceivedExcelReportItem
                                                                    , IssuedExcelReportItem
                                                                                , row, headers);




            MASReport.Protection.IsProtected = false;
            MemoryStream ms = new MemoryStream();
                exlPackage.SaveAs(ms);
                return ms;
          
        }

        MemoryStream IGenerateExcelReport.GenerateExcelBalanceQuantityReport(List<Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt
             ,DTOExcelReportInput dTOExcelReportInput)
        {
            
            ExcelPackage exlPackage = new ExcelPackage();
            ExcelWorksheet BQReport = exlPackage.Workbook.Worksheets.Add("Balance Quantity Report");
            BQReport.Column(1).Width = 5;
            BQReport.Column(2).Width = 65;
            BQReport.Column(3).Width = 12;
            BQReport.Column(4).Width = 7;

            int row = 1, col = 1, rowSpan = 0, colSpan = 4;
            string cellValue = "Balance Quantity of " + dTOExcelReportInput.StoreName + " on date " + dTOExcelReportInput.StartDate.ToDate();
            WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 11);

            row++; col = 1; rowSpan = 1; colSpan = 1;
            cellValue = "Sno.";
            WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++; 
            cellValue = "Name of Materias";
            WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Balance Qty";
            WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Unit";
            WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            foreach (Core.ViewModel.MasterRegisterExtension mre in listMasterRegisterExt)
            {
                row++; col = 1; rowSpan = 1; colSpan = 1;
                cellValue = mre.SerialNumber.ToString();
                WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                cellValue = mre.MaterialNameWithDescription;
                WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                cellValue = mre.Quantity.ToString();
                WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                cellValue = mre.MaterialUnit;
                WorkSheetWriter.SetCell(BQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);

            }



            BQReport.Protection.IsProtected = false;
            MemoryStream ms = new MemoryStream();
            exlPackage.SaveAs(ms);
            return ms;
        }


        MemoryStream IGenerateExcelReport.GenerateExcelAmountBalanceQuantityReport(List<Core.ViewModel.MasterRegisterExtension> listMasterRegisterExt
             , DTOExcelReportInput dTOExcelReportInput)
        {

            ExcelPackage exlPackage = new ExcelPackage();
            ExcelWorksheet ABQReport = exlPackage.Workbook.Worksheets.Add("Amount Balance Quantity Report");
            ABQReport.Column(1).Width = 5;
            ABQReport.Column(2).Width = 65;
            ABQReport.Column(3).Width = 12;
            ABQReport.Column(4).Width = 7;
            ABQReport.Column(5).Width = 12;
            ABQReport.Column(6).Width = 15;

            decimal deciCellValue = 0;

            int row = 1, col = 1, rowSpan = 0, colSpan = 6;
            string cellValue = "Amount of Balance Quantity of " + dTOExcelReportInput.StoreName + " on date " + dTOExcelReportInput.StartDate.ToDate();
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 11);

            row++; col = 1; rowSpan = 1; colSpan = 1;
            cellValue = "Sno.";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Name of Materias";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Qty";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Unit";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Rate";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col++;
            cellValue = "Amount";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            foreach (Core.ViewModel.MasterRegisterExtension mre in listMasterRegisterExt)
            {
                row++; col = 1; rowSpan = 1; colSpan = 1;
                cellValue = mre.SerialNumber.ToString();
                WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                cellValue = mre.MaterialNameWithDescription;
                WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                deciCellValue = mre.Quantity;
                WorkSheetWriter.SetCell(ABQReport, deciCellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                cellValue = mre.MaterialUnit;
                WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                deciCellValue = mre.MaterialRate;
                WorkSheetWriter.SetCell(ABQReport, deciCellValue, row, col, rowSpan, colSpan, isBold: false);
                col++;
                deciCellValue = mre.Quantity* mre.MaterialRate;
                WorkSheetWriter.SetCell(ABQReport, deciCellValue, row, col, rowSpan, colSpan, isBold: false);

            }

            row++; col = 1; rowSpan = 1; colSpan = 5;
            cellValue = "Total";
            WorkSheetWriter.SetCell(ABQReport, cellValue, row, col, rowSpan, colSpan, isBold: true);

            col=col+colSpan;colSpan = 1;
            WorkSheetWriter.SetAddFormulaOnCell(ABQReport, row, col, rowSpan, colSpan,3, listMasterRegisterExt.Count+2, isBold: true);

            ABQReport.Protection.IsProtected = false;
            MemoryStream ms = new MemoryStream();
            exlPackage.SaveAs(ms);
            return ms;
        }

        private string storeHeaderName(DTOExcelReportInput dTOExcelReportInput)
        {
            string result = string.Empty;
            string fromdate=string.Empty, todate=string.Empty;
            if (dTOExcelReportInput.StartDate != null)
                fromdate = dTOExcelReportInput.StartDate.ToDate();
            if (dTOExcelReportInput.EndDate != null)
                todate = dTOExcelReportInput.EndDate.ToDate();

            result = dTOExcelReportInput.StoreName;
            if (fromdate != string.Empty && todate != string.Empty)
            {
                result = result + " " + fromdate + " to " + todate;
            }
            return result;
        }
    }
}



 //using (MemoryStream ms = new MemoryStream())
 //           {
 //               exlPackage.SaveAs(ms);

 //               using (FileStream fs = new FileStream("output.xlsx", FileMode.OpenOrCreate))
 //               {
 //                   ms.CopyTo(fs);
 //                   fs.Flush();
 //               }
 //           }
