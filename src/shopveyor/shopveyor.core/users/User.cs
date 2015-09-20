using shopveyor.core.infrastructure;
using System;

namespace shopveyor.core.users
{
    public abstract class User : IAggregateRoot, IUser
    {
        protected readonly DateTime _dateJoined;

        protected User(DateTime dateJoined)
        {
            if (dateJoined > DateTime.UtcNow)
            {
                throw new ArgumentException("Cannot join user with a future join date");
            }

            _dateJoined = dateJoined;
        }

        public virtual decimal Discount => 0;

        public DateTime DateJoined => _dateJoined;
    }
}
