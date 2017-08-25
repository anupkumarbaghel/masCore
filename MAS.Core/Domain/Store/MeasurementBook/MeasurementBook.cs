using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace MAS.Core.Domain.Store.MeasurementBook
{
    public class MeasurementBook : AuditBaseDomain<long>
    {
        [StringLength(200)]
        public virtual string NameOfContractor { get; set; }
        [StringLength(200)]
        public virtual string AggrementNumber { get; set; }
        [StringLength(200)]
        public virtual string WorkOrderNumber { get; set; }
        [StringLength(200)]
        public virtual string MBNumber { get; set; }

        public virtual DateTime? MeasurementDate { get; set; }

        [StringLength(10)]
        public virtual string PageNumber { get; set; }
        public virtual ICollection<MeasurementBookTable> MBTable { get; set; }
        [StringLength(10)]
        public virtual string MeasurementBookStatus { get; set; }

        public virtual int StoreID { get; set; }
    }
}
