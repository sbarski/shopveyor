using System;
using System.Configuration;

namespace shopveyor.core.users
{
    public class Affiliate : User
    {
        public Affiliate(DateTime dateJoined)
            : base(dateJoined)
        {
        }

        public override decimal Discount => Convert.ToDecimal(ConfigurationManager.AppSettings["affiliatediscount"]);
    }
}
