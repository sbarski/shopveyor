using shopveyor.core.products;

namespace shopveyor.core.order
{
    /// <summary>
    /// The order item entity allows product pricing to change without affecting existing or historical orders.
    /// </summary>
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
