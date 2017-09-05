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

namespace MAS.ExcelReport
{
    public class GenerateExcelReport : IGenerateExcelReport
    {
        MemoryStream IGenerateExcelReport.GenerateExcelReport(List<MasterRegister> masterRegister,IEnumerable<Indent> indents,IEnumerable<MeasurementBook> mbs)
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
            string cellValue = "MAS ACCOUNT for Simhastha 2016  - Month of April 2016";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 14);

            ///////
            row++; col = 1; rowSpan = 3; colSpan = 0;
            cellValue = "Date of Reciept / Issue";
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
            List<MASMaterialHeader> headers = headerConverter.GenerateHeader(masterRegister);

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
