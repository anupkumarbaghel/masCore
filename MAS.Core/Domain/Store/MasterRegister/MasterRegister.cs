using MAS.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS.Core.Domain.Store.MasterRegister
{
    public class MasterRegister : AuditBaseDomain
    {       
        public virtual int SerialNumber { get; set; }
       
        public virtual string MaterialNameWithDescription { get; set; }

        [StringLength(20)]
        public virtual string MaterialUnit { get; set; }

        public virtual decimal MaterialRate { get; set; }

        public virtual int StoreID { get; set; }

    }
}
