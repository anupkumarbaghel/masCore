using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal class IndentMBExcelReportModel
    {
        public DateTime DateOfReciept { get; set; }
        public string IndentNoNDate { get; set; }
        public string ReceivedIssue { get; set; }
        public string HeadOfAccount { get; set; }
        public ICollection<IndentMBMaterialExcelReport> IndentMBMaterials { get; set; }
    }

    internal class IndentMBMaterialExcelReport
    {
        public int MasterRegisterID { get; set; }
        public decimal Quantity { get; set; }
    }
}
