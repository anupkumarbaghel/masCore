using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.ViewModel
{
    public class MasterRegisterExtension :MAS.Core.Domain.Store.MasterRegister.MasterRegister
    {
        public virtual decimal Quantity { get; set; }
    }
}
