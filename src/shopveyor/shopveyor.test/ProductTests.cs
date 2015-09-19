using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopveyor.core.products;
using Xunit;

namespace shopveyor.test
{
    public class ProductTests
    {
        [Fact]
        public void Can_Create_Non_Grocery_Product()
        {
            var product = new Product(25);
            Assert.Equal(25, product.Price);
            Assert.False(product.IsGrocery);
        }

        [Fact]
        public void Can_Create_Grocery_Product()
        {
            var product = new Product(45, true);
            Assert.Equal(45, product.Price);
            Assert.True(product.IsGrocery);
        }
    }
}
