using System;
using System.Configuration;

namespace shopveyor.core.users
{
    public class Employee : User
    {
        public Employee(DateTime dateJoined)
            : base(dateJoined)
        {
        }

        public override decimal Discount => Convert.ToDecimal(ConfigurationManager.AppSettings["employeediscount"]);
    }
}
