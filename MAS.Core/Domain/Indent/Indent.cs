using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Base;

namespace MAS.Core.Domain.Indent
{
    public class Indent : AuditBaseDomain<long>
    {
        public virtual string IndentNumber { get; set; }
        public virtual DateTime? IndentDate { get; set; }
        public virtual string ProvidedTo { get; set; }
        public virtual string ProvidedBy { get; set; }
        public virtual string ProvidedOn { get; set; }
        public virtual string IssuedBy { get; set; }
        public virtual ICollection<IndentTable> IndentTableCollection { get; set; }
    }
}
