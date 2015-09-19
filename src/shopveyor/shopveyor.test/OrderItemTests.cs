using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopveyor.core.order;
using shopveyor.core.products;
using Xunit;

namespace shopveyor.test
{
    public class OrderItemTests
    {
        [Fact]
        public void Can_Create_Valid_OrderItem()
        {
            var nonGroceryProduct = new Product(25);
            var groceryProduct = new Product(50, true);

            var nonGroceryOrderItem = new OrderItem(nonGroceryProduct);

            Assert.Equal(nonGroceryProduct.Price, nonGroceryOrderItem.Price);
            Assert.Equal(nonGroceryProduct, nonGroceryOrderItem.Product);

            var groceryOrderItem = new OrderItem(groceryProduct);

            Assert.Equal(groceryProduct.Price, groceryOrderItem.Price);
            Assert.Equal(groceryProduct, groceryOrderItem.Product);
        }
    }
}
