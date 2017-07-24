using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Base
{
    interface IEntity<DataType>
    {
        DataType ID { get; set; }
    }
}
