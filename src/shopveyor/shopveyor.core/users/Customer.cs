using System;
using System.Configuration;

namespace shopveyor.core.users
{
    public class Customer : User
    {
        public Customer(DateTime dateJoined)
            : base(dateJoined)
        {

        }

        public override decimal Discount
        {
            get 
            {
                //The standard library will calculate the 2 year gap correctly taking in to account leap years, and time drift over the year
                if (_dateJoined.AddYears(2) < DateTime.UtcNow)
                {
                    return Convert.ToDecimal(ConfigurationManager.AppSettings["customerdiscount"]);
                }
                
                return base.Discount;
            }
        }
    }
}
