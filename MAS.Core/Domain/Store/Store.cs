using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace MAS.Core.Domain.Store
{
    public class Store : AuditBaseDomain
    {
        [StringLength(200)]
        public virtual string Name { get; set; }

        
        public virtual string Description { get; set; }

        [StringLength(1000)]
        public virtual string Key { get; set; }

        public virtual int AdminID { get; set; }

        public virtual ICollection<Indent.Indent> IndentCollection { get; set; }
        public virtual ICollection<MeasurementBook.MeasurementBook> MeasurementBookCollection { get; set; }
    }
}
