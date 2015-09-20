using shopveyor.core.infrastructure;

namespace shopveyor.core.products
{
    /// <summary>
    /// The product class that contains pricing and a grocery flag
    /// </summary>
    public class Product : IAggregateRoot, IProduct
    {
        public Product(decimal price, bool isGrocery = false)
        {
            IsGrocery = isGrocery;
            Price = price;
        }

        public decimal Price { get; }

        public bool IsGrocery { get; }
    }
}
