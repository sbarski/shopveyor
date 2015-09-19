using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopveyor.core.users
{
    public class Affiliate : User
    {
        public Affiliate(DateTime dateJoined)
            : base(dateJoined)
        {
        }

        public override decimal Discount
        {
            get 
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings["affiliatediscount"]);
            }
        }
    }
}
