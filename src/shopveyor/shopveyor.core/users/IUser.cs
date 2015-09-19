using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopveyor.core.users
{
    public interface IUser
    {
        decimal Discount { get; }
        DateTime DateJoined { get; }
    }
}
