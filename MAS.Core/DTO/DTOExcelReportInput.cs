using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.DTO
{
    public class DTOExcelReportInput
    {
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string StoreName { get; set; }
        public virtual string ReportUrl { get; set; }
        public virtual int StoreID { get; set; }
        public virtual string ReportType { get; set; }
    }
}
