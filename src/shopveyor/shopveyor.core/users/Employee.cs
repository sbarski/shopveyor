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

        public override decimal Discount
        {
            get
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings["employeediscount"]);
            }
        }
    }
}
