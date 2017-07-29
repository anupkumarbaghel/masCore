using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Interface.Base;

namespace MAS.Core.Domain.Base
{
    public abstract class BaseDomain<DataType> : IEntity<DataType>,IHasColumnDelete
    {
        public DataType ID { get; set;}
        public bool IsDelete { get; set; }
    }

    public abstract class BaseDomain : BaseDomain<int> { }
}
