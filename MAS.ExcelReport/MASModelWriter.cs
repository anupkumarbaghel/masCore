using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal class MASModelWriter
    {
        int _endCalculationRow = 0;
        int _endCalculationRowIssue = 0;
        int _issueStartRow = 0;
        int _receiveStartRow = 0;

        public MASModelWriter(ExcelWorksheet MASReport, List<IndentMBExcelReportModel> receiveModels
            , List<IndentMBExcelReportModel> issueModels
            , int startRow
            , List<MASMaterialHeader> headers)
        {
            _receiveStartRow = startRow;
            WriteModel(MASReport, receiveModels, issueModels, startRow, headers);
        }

        private int findColumnNumber(List<MASMaterialHeader> headers,int indentMasterID)
        {
           
            foreach (MASMaterialHeader header in headers)
            {
                if (header.level == 1)
                {
                    if (header.level1.leafVallue.MasterRegisterID == indentMasterID)
                    {
                       return header.level1.leafVallue.ColumnNumber;
                    }
                }
                else if (header.level == 2)
                {
                    foreach (Level2 l2 in header.level1.level2s)
                    {
                        if (l2.leafVallue.MasterRegisterID == indentMasterID)
                        {
                            return l2.leafVallue.ColumnNumber;
                        }
                    }
                }
                else if (header.level == 3)
                {
                    foreach (Level2 l2 in header.level1.level2s)
                    {
                        foreach (Level3 l3 in l2.level3s)
                        {
                            if (l3.leafVallue.MasterRegisterID == indentMasterID)
                            {
                                return l3.leafVallue.ColumnNumber;
                            }
                        }
                    }
                }
                else
                {
                    return 1;
                }
            }

            return 1;
        }

        private void WriteModel(ExcelWorksheet MASReport,List<IndentMBExcelReportModel> receiveModels
            , List<IndentMBExcelReportModel> issueModels
            , int startRow
            , List<MASMaterialHeader> headers)
        {
            int row = startRow, col = 1, rowSpan = 1, colSpan = 1;
            string cellValue = string.Empty;

            WriteModelSub(MASReport, receiveModels, headers, ref row, ref col, rowSpan, colSpan, ref cellValue);

            WriteModelFooterReceive(MASReport, startRow, headers, ref row, ref col, rowSpan, out colSpan, out cellValue);

            col = 1; rowSpan = 0; colSpan = 4;
            cellValue = "Issue during the month";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 11, isBackColorYellow: true);
            row++;colSpan = 1;

            WriteModelSub(MASReport, issueModels, headers, ref row, ref col, rowSpan, colSpan, ref cellValue);

            WriteModelFooterIssue(MASReport, _issueStartRow, headers, ref row, ref col, rowSpan, out colSpan, out cellValue);

        }
        private void WriteModelSub(ExcelWorksheet MASReport, List<IndentMBExcelReportModel> models, List<MASMaterialHeader> headers, ref int row, ref int col, int rowSpan, int colSpan, ref string cellValue)
        {
            foreach (IndentMBExcelReportModel model in models)
            {
                cellValue = model.DateOfReciept.ToDate();
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: false);

                col++;
                cellValue = model.IndentNoNDate;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: false);

                col++;
                cellValue = model.ReceivedIssue;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: false);

                col++;
                cellValue = model.HeadOfAccount;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: false);

                foreach (var excelMaterial in model.IndentMBMaterials)
                {
                    col = findColumnNumber(headers, excelMaterial.MasterRegisterID);
                    decimal decimalCellValue = excelMaterial.Quantity;
                    WorkSheetWriter.SetCell(MASReport, decimalCellValue, row, col, rowSpan, colSpan, isBold: false);
                }

                row++;
                col = 1;
            }
        }
        private void WriteModelFooterReceive(ExcelWorksheet MASReport, int startRow, List<MASMaterialHeader> headers, ref int row, ref int col, int rowSpan, out int colSpan, out string cellValue)
        {
            _endCalculationRow = row - 1;
            colSpan = 4;
            cellValue = "Total Received during the month";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);
            int lastColumn = 5;
            foreach (var header in headers)
            {
                lastColumn += header.level1.ColSpan;
            }
            for (int i = 5; i < lastColumn; i++)
            {
                col = i; colSpan = 1;
                WorkSheetWriter.SetAddFormulaOnCell(MASReport, row, col, rowSpan, colSpan, startRow, _endCalculationRow, isBold: true);
            }
            row++; col = 1; colSpan = 4;
            cellValue = "Total Upto date Received";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);
            for (int i = 5; i < lastColumn; i++)
            {
                col = i; colSpan = 1;
                WorkSheetWriter.SetAddFormulaOnCell(MASReport, row, col, rowSpan, colSpan, startRow - 2, _endCalculationRow, isBold: true);
            }
            col = 1;row++; _issueStartRow = row+1;
        }

        private void WriteModelFooterIssue(ExcelWorksheet MASReport, int startRow, List<MASMaterialHeader> headers, ref int row, ref int col, int rowSpan, out int colSpan, out string cellValue)
        {
            _endCalculationRowIssue = row - 1;
            colSpan = 4;
            cellValue = "Total Issue during the month";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);
            int lastColumn = 5;
            foreach (var header in headers)
            {
                lastColumn += header.level1.ColSpan;
            }
            for (int i = 5; i < lastColumn; i++)
            {
                col = i; colSpan = 1;
                WorkSheetWriter.SetAddFormulaOnCell(MASReport, row, col, rowSpan, colSpan, startRow, _endCalculationRowIssue, isBold: true);
            }
            row++; col = 1; colSpan = 4;
            cellValue = "Closing Balance";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true);
            for (int i = 5; i < lastColumn; i++)
            {
                col = i; colSpan = 1;
                WorkSheetWriter.SetAddFormulaOnCell(MASReport
                    , row, col, rowSpan, colSpan
                    ,_issueStartRow
                    ,_endCalculationRowIssue
                    ,_receiveStartRow
                    ,_endCalculationRow
                    , isBold: true);
            }
           //MAS ends here
        }
    }
}
