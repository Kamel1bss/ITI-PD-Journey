using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_2_OCP.Payment_case
{
    internal interface IPayment
    {
        void ProcessPayment(decimal amount);
    }
}
