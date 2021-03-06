﻿using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;
using System.ComponentModel.DataAnnotations;


namespace MAS.Core.Domain.Store.Indent
{
    public class Indent : AuditBaseDomain<long>
    {
        [StringLength(200)]
        public virtual string IndentNumber { get; set; }
   
        public virtual DateTime? IndentDate { get; set; }
        public virtual DateTime? SubmittedDate { get; set; }
        [StringLength(200)]
        public virtual string ProvidedTo { get; set; }
        [StringLength(200)]
        public virtual string ProvidedBy { get; set; }
        [StringLength(200)]
        public virtual string ProvidedOn { get; set; }
        [StringLength(200)]
        public virtual string IssuedBy { get; set; }
        public virtual ICollection<IndentTable> IndentTableCollection { get; set; }
        [StringLength(10)]
        public virtual string IndentStatus { get; set; }

        [StringLength(200)]
        public virtual string HeadOfAccount { get; set; }

        public virtual Boolean IsReceive { get; set; }

        public virtual Boolean IsSitework { get; set; }

        public virtual int StoreID { get; set; }

       
    }
}
