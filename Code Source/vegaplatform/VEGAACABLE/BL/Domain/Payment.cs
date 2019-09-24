using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public enum PaymentStatus : byte
    {
        Unpaid = 0,
        Paid = 1
    }

    public enum PaymentMethod
    {
        Held = 0,
        Term = 1,
        Cash = 2,
        Bank = 3
    }
}
