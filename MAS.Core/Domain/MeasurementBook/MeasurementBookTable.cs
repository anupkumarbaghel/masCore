using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;

namespace MAS.Core.Domain.MeasurementBook
{
    public class MeasurementBookTable : AuditBaseDomain<long>
    {
        public virtual string SerialNumber { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string HeadOfAccount { get; set; }
        public virtual long MeasurementBookTableID { get; set; }
    }
}
