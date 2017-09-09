using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal class WorkSheetWriter
    {
        public static int SetCell(ExcelWorksheet ws, string cellValue, int row, int col, int rowSpan = 0, int colSpan = 0, bool isBold = false, float textSize = 9, bool isBackColorYellow = false)
        {
            if (rowSpan > 0) rowSpan--; if (colSpan > 0) colSpan--;
            ExcelRange cell = ws.Cells[row, col, row + rowSpan, col + colSpan];
            cell.Merge = true;
            cell.Value = cellValue;
            cell.Style.Font.Bold = isBold;
            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            cell.Style.WrapText = true;
            cell.Style.Font.Size = textSize;
            cell.Style.Font.Name = "Arial";
            cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            if (isBackColorYellow)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
            }
            return cell.Start.Column;
        }
        public static int SetCell(ExcelWorksheet ws, decimal cellValue, int row, int col, int rowSpan = 0, int colSpan = 0, bool isBold = false, float textSize = 9, bool isBackColorYellow = false)
        {
            if (rowSpan > 0) rowSpan--; if (colSpan > 0) colSpan--;
            ExcelRange cell = ws.Cells[row, col, row + rowSpan, col + colSpan];
            cell.Merge = true;
            cell.Value = cellValue;
            cell.Style.Font.Bold = isBold;
            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            cell.Style.WrapText = true;
            cell.Style.Font.Size = textSize;
            cell.Style.Font.Name = "Arial";
            cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            cell.Style.Numberformat.Format = "0.00";
            //if(isBackColorYellow) cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
            return cell.Start.Column;
        }
        public static int SetAddFormulaOnCell(ExcelWorksheet ws,int row, int col, int rowSpan, int colSpan,int startRow,int endRow, bool isBold = false, float textSize = 9, bool isBackColorYellow = false)
        {
            if (rowSpan > 0) rowSpan--; if (colSpan > 0) colSpan--;
            ExcelRange cell = ws.Cells[row, col, row + rowSpan, col + colSpan];
            cell.Merge = true;
            cell.Style.Font.Bold = isBold;
            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            cell.Style.WrapText = true;
            cell.Style.Font.Size = textSize;
            cell.Style.Font.Name = "Arial";
            cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            cell.Style.Numberformat.Format = "0.00";
            //if(isBackColorYellow) cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
            char ltrcell=  cell.Address.ToCharArray()[0];
            string formula ="SUM("+ ltrcell + startRow.ToString() + ":" + ltrcell + endRow+")";
            cell.Formula = formula;
            return cell.Start.Column;
        }
        public static string SetClosingBalanceFormula(ExcelWorksheet ws, int row, int col, int rowSpan, int colSpan, int receiveRow, int issueRow, bool isBold = false, float textSize = 9, bool isBackColorYellow = false)
        {
            if (rowSpan > 0) rowSpan--; if (colSpan > 0) colSpan--;
            ExcelRange cell = ws.Cells[row, col, row + rowSpan, col + colSpan];
            cell.Merge = true;
            cell.Style.Font.Bold = isBold;
            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            cell.Style.WrapText = true;
            cell.Style.Font.Size = textSize;
            cell.Style.Font.Name = "Arial";
            cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            cell.Style.Numberformat.Format = "0.00";
            //if(isBackColorYellow) cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
            char ltrcell = cell.Address.ToCharArray()[0];
            string formula = ltrcell + receiveRow.ToString() + "-" + ltrcell + issueRow.ToString();
            cell.Formula = formula;
            return cell.Address;
        }
    }
}
