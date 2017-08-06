using MAS.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MAS.Core.Domain.Admin
{
    public class Admin : AuditBaseDomain
    {
        [StringLength(200)]
        public virtual string Name { get; set; }

        [StringLength(1000)]
        public virtual string Key { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<Store.Store> StoreCollection { get; set; }
    }
}
