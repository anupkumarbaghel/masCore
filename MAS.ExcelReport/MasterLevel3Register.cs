using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal class MasterLevel3Register
    {
        public virtual int SerialNumber { get; set; }
        public virtual string Level1 { get; set; }
        public virtual string Level2 { get; set; }
        public virtual string Level3 { get; set; }
        public virtual string MaterialUnit { get; set; }
        public int MasterRegisterID { get; set; }
    }
}
