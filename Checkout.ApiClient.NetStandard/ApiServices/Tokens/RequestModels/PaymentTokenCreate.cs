using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Charges.RequestModels;
using Checkout.ApiServices.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;
using Checkout.ApiServices.RecurringPayments.RequestModels;

namespace Checkout.ApiServices.Tokens.RequestModels
{
    public class PaymentTokenCreate : BaseCharge
    {
        public bool AttemptN3D { get; set; } = true;
        public List<CustomerPaymentPlanCreate> PaymentPlans { get; set; }
    }
}
