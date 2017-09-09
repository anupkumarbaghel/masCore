using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal class MaterialHeaderWriter
    {
        List<MASMaterialHeader> _headers;
        ExcelWorksheet MASReport;
        int _StartColumn, _TopHeaderColspan, _TopHeaderStart;

        public MaterialHeaderWriter(List<MASMaterialHeader> headers, ExcelWorksheet ExcelSheet, int StartColumn)
        {
            _headers = headers;
            MASReport = ExcelSheet;
            _StartColumn = StartColumn;
            _TopHeaderStart = StartColumn;
        }
        public void WriteHeader()
        {
            foreach (MASMaterialHeader header in _headers)
            {
                switch (header.level)
                {
                    case 1:
                        _StartColumn = WriteLevel1Header(header);
                        break;
                    case 2:
                        _StartColumn = WriteLevel2Header(header);
                        break;
                    case 3:
                        _StartColumn = WriteLevel3Header(header);
                        break;
                }

            }
            _TopHeaderColspan = _StartColumn - _TopHeaderStart;
            int row = 1, col = _TopHeaderStart, rowSpan = 0, colSpan = _TopHeaderColspan;
            string cellValue = "Name of Material";
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);
        }
        private int WriteLevel1Header(MASMaterialHeader header)
        {
            header.level1.ColSpan = 1;
            int row = 2, col = _StartColumn, rowSpan = 3, colSpan = 1;
            string cellValue = header.level1.MainContent;
            header.level1.leafVallue.ColumnNumber = WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            row = row + rowSpan; rowSpan = 1;
            cellValue = header.Unit;
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            row = row + rowSpan; rowSpan = 1;
            cellValue = header.level1.leafVallue.Sno;
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            row = row + rowSpan; rowSpan = 1;
            decimal deciCellValue = header.level1.leafVallue.OpeningBalance;
            WorkSheetWriter.SetCell(MASReport, deciCellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            return _StartColumn + colSpan;
        }
        private int WriteLevel2Header(MASMaterialHeader header)
        {
            header.level1.ColSpan = header.level1.level2s.Count;

            int row = 2, col = _StartColumn, rowSpan = 0, colSpan = header.level1.ColSpan;
            string cellValue = header.level1.MainContent;
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            int rowstartl2 = 3, colstartl2 = _StartColumn;
            foreach (Level2 l2 in header.level1.level2s)
            {
                row = rowstartl2; col = colstartl2; rowSpan = 2; colSpan = 1;
                cellValue = l2.MainContent;
                l2.leafVallue.ColumnNumber = WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                row = row + rowSpan; rowSpan = 1; colSpan = 1;
                cellValue = header.Unit;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                row = row + rowSpan; rowSpan = 1; colSpan = 1;
                cellValue = l2.leafVallue.Sno;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                row = row + rowSpan; rowSpan = 1; colSpan = 1;
                decimal deciCellValue = l2.leafVallue.OpeningBalance;
                WorkSheetWriter.SetCell(MASReport, deciCellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);


                colstartl2 += colSpan;

            }
            return _StartColumn + header.level1.ColSpan;
        }
        private int WriteLevel3Header(MASMaterialHeader header)
        {
            int totalColumn = 0;
            foreach (Level2 l2 in header.level1.level2s)
            {
                l2.ColSpan = l2.level3s.Count;
                totalColumn += l2.ColSpan;
                header.level1.ColSpan = totalColumn;
            }

            int row = 2, col = _StartColumn, rowSpan = 0, colSpan = header.level1.ColSpan;
            string cellValue = header.level1.MainContent;
            WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

            int rowstartl2 = 3, colstartl2 = _StartColumn, colstartl3 = _StartColumn, rowstartl3 = 4;
            foreach (Level2 l2 in header.level1.level2s)
            {
                row = rowstartl2; col = colstartl2; rowSpan = 0; colSpan = l2.ColSpan;
                cellValue = l2.MainContent;
                WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);
                colstartl2 += colSpan;
                foreach (Level3 l3 in l2.level3s)
                {
                    row = rowstartl3; col = colstartl3; rowSpan = 1; colSpan = 1;
                    cellValue = l3.MainContent;
                    l3.leafVallue.ColumnNumber = WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                    row = row + rowSpan; rowSpan = 1; colSpan = 1;
                    cellValue = header.Unit;
                    WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                    row = row + rowSpan; rowSpan = 1; colSpan = 1;
                    cellValue = l3.leafVallue.Sno;
                    WorkSheetWriter.SetCell(MASReport, cellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);

                    row = row + rowSpan; rowSpan = 1; colSpan = 1;
                    decimal deciCellValue = l3.leafVallue.OpeningBalance;
                    WorkSheetWriter.SetCell(MASReport, deciCellValue, row, col, rowSpan, colSpan, isBold: true, textSize: 9);


                    colstartl3 += colSpan;

                }
            }

            return _StartColumn + header.level1.ColSpan;
        }
    }
}
