using System;
using System.Collections.Generic;
using Checkout.ApiServices.RecurringPayments.RequestModels;

namespace Checkout.ApiServices.Charges.RequestModels
{
    public class CardTokenCharge : DefaultCardCharge
    {
        public string CardToken { get; set; }
    }
}
