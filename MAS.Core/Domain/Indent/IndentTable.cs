using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;

namespace MAS.Core.Domain.Indent
{
    public class IndentTable : AuditBaseDomain<long>
    {
        public virtual string SerialNo { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string HeadOfAccount { get; set; }
        public virtual string ContractorName { get; set; }
        public virtual long IndentID { get; set; }
    }
}
