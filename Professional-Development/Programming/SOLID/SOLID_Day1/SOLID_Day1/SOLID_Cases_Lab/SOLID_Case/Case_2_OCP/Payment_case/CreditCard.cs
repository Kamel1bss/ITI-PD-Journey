using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_2_OCP.Payment_case
{
    internal class CreditCard: IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            // Code to process credit card payment
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
    
    }
}
