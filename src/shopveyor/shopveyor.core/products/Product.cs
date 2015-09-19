using shopveyor.core.infrastructure;

namespace shopveyor.core.products
{
    /// <summary>
    /// The product class that contains pricing and a grocery flag
    /// </summary>
    public class Product : IAggregateRoot, IProduct
    {
        private readonly bool _isGrocery;
        private readonly decimal _price;

        public Product(decimal price, bool isGrocery = false)
        {
            _isGrocery = isGrocery;
            _price = price;
        }

        public decimal Price
        {
            get 
            {
                return _price;
            }
        }

        public bool IsGrocery
        {
            get
            {
                return _isGrocery;
            }
        }
    }
}
