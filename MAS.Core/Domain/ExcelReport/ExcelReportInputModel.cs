using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Domain.ExcelReport
{
    public class ExcelReportInputModel
    {
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual int StoreID { get; set; }
    }
}
