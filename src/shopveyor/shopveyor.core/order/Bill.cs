using System;
using shopveyor.core.infrastructure;
using shopveyor.core.products;
using shopveyor.core.users;
using System.Collections.Generic;
using System.Configuration;

namespace shopveyor.core.order
{
    /// <summary>
    /// The bill domain entity that contains a collection of order items and carries out calculations
    /// </summary>
    public class Bill : IAggregateRoot, IBill
    {
        private readonly IUser _user;
        private readonly IList<IOrderItem> _orderItems;
        private readonly decimal _finalDiscount;

        public Bill(IUser user)
        {
            _user = user;
            _finalDiscount = Convert.ToDecimal(ConfigurationManager.AppSettings["finaldiscount"]);
            _orderItems = new List<IOrderItem>();
        }

        public decimal Total()
        {
            var total = 0.0M;

            //Work out total with discounts
            foreach (var orderItem in _orderItems)
            {
                total += orderItem.Product.IsGrocery ? orderItem.Price : (orderItem.Price - (orderItem.Price * _user.Discount));
            }

            return CalculateSecondaryDiscount(total);
        }

        private decimal CalculateSecondaryDiscount(decimal total)
        {
            //Work out total with $5 cashback
            var numberOfHundreds = (int)total / 100;

            total -= (_finalDiscount * numberOfHundreds);

            return total;
        }

        public IOrderItem AddToBill(IProduct product)
        {
            var orderItem = new OrderItem(product);

            _orderItems.Add(orderItem);

            return orderItem;
        }

        public IUser User
        {
            get { return _user; }
        }

        public IEnumerable<IOrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
        }
    }
}
