using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_2_OCP
{
    #region Bad Code
    class PaymentProcessor
    {
        public void ProcessPayment(string paymentType)
        {
            if (paymentType == "CreditCard")
            {
                // Process credit card payment
            }
            else if (paymentType == "PayPal")
            {
                // Process PayPal payment
            }
        }
    }

    #endregion
}
