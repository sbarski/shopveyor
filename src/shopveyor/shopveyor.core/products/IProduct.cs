using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopveyor.core.products
{
    public interface IProduct
    {
        decimal Price { get; }

        bool IsGrocery { get; }
    }
}
