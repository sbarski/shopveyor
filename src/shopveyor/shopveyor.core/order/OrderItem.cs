using shopveyor.core.products;

namespace shopveyor.core.order
{
    public class OrderItem : IOrderItem
    {
        private readonly IProduct _product;
        private readonly decimal _price;

        public OrderItem(IProduct product)
        {
            _product = product;
            _price = product.Price;
        }

        public IProduct Product
        {
            get
            {
                return _product;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
        }
    }
}
