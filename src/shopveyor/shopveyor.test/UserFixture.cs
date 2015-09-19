using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopveyor.core.users;

namespace shopveyor.test
{
    public class UserFixture
    {
        public IUser OldCustomer { get; protected set; } //Over 2 years
        public IUser NewCustomer { get; protected set; } //Under 2 years
        public IUser Employee { get; protected set; }
        public IUser Affiliate { get; protected set; }
          
        public UserFixture()
        {
            OldCustomer = new Customer(DateTime.UtcNow.Subtract(TimeSpan.FromDays(735)));
            NewCustomer = new Customer(DateTime.UtcNow);
            Employee = new Employee(DateTime.UtcNow);
            Affiliate = new Affiliate(DateTime.UtcNow);
        }
    }
}
