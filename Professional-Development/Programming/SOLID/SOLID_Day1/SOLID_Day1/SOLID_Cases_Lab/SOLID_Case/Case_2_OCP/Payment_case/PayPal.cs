using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_2_OCP.Payment_case
{
    internal class PayPal : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            // Code to process PayPal payment
            Console.WriteLine($"Processing PayPal payment of {amount}");
        }
    }
}
