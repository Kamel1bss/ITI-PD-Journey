using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_2_OCP.Payment_case
{
    internal class GoodPaymentProcessor
    {
        private readonly IPayment _payment;
        public GoodPaymentProcessor(IPayment payment)
        {
            _payment = payment;
        }
        public void ProcessPayment(decimal amount)
        {
            //if (paymentType == "CreditCard")
            //{
            //    // Process credit card payment
            //}
            //else if (paymentType == "PayPal")
            //{
            //    // Process PayPal payment
            //}

            _payment.ProcessPayment(amount); // Example amount
        }
    }
}
