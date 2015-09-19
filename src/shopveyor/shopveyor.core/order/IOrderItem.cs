using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopveyor.core.infrastructure;
using shopveyor.core.products;

namespace shopveyor.core.order
{
    public interface IOrderItem : IEntity
    {
        IProduct Product { get; }
        decimal Price { get; }
    }
}
