using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;

namespace MAS.Core.Domain.MeasurementBook
{
    public class MeasurementBook : AuditBaseDomain<long>
    {
        public virtual string NameOfContractor { get; set; }
        public virtual string AggrementNumber { get; set; }
        public virtual string WorkOrderNumber { get; set; }
        public virtual string MBNumber { get; set; }
        public virtual string PageNumber { get; set; }
        public virtual ICollection<MeasurementBookTable> MBTable { get; set; }
    }
}
