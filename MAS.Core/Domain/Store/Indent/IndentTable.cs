using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace MAS.Core.Domain.Store.Indent
{
    public class IndentTable : AuditBaseDomain<long>
    {
        [StringLength(200)]
        public virtual string SerialNo { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Quantity { get; set; }
        [StringLength(200)]
        public virtual string HeadOfAccount { get; set; }
        [StringLength(200)]
        public virtual string ContractorName { get; set; }
        public virtual MasterRegister.MasterRegister MasterRegister { get; set; }
        public virtual long IndentID { get; set; }
    }
}
