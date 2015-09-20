using shopveyor.core.products;

namespace shopveyor.core.order
{
    /// <summary>
    /// The order item entity allows product pricing to change without affecting existing or historical orders.
    /// </summary>
    public class OrderItem : IOrderItem
    {
        public OrderItem(IProduct product)
        {
            Product = product;
            Price = product.Price;
        }

        public IProduct Product { get; }

        public decimal Price { get; }
    }
}
