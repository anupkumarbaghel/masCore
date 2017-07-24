using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Interface.Base;

namespace MAS.Core.Domain.Base
{
    public abstract class BaseDomain<DataType> : IEntity<DataType>
    {
        public DataType ID { get; set; }
    }

    public abstract class BaseDomain : BaseDomain<int> { }
}
