using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Interface.Base;

namespace MAS.Core.Domain.Base
{
    public abstract class AuditBaseDomain<DataType> : BaseDomain<DataType>,IHasCreatedBy,IHasModifiedBy,IHasCreatedDate,IHasModifiedDate
    {
        public AuditBaseDomain()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get;set; }
    }

    public abstract class AuditBaseDomain : AuditBaseDomain<int> { }
}
