using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Base
{
    interface IHasModifiedDate
    {
        DateTime ModifiedDate { get; set; }
    }
}
