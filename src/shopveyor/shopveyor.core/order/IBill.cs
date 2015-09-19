using shopveyor.core.products;
using shopveyor.core.users;
using System.Collections.Generic;

namespace shopveyor.core.order
{
    public interface IBill
    {
        IOrderItem AddToBill(IProduct orderItems);

        IEnumerable<IOrderItem> OrderItems { get; }

        decimal Total();

        IUser User { get; }
    }
}
