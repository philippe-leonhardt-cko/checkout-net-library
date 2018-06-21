using System;
using System.Collections.Generic;
using Checkout.ApiServices.RecurringPayments.RequestModels;

namespace Checkout.ApiServices.Charges.RequestModels
{
    public class CardIdCharge : DefaultCardCharge
    {
        public string Cvv { get; set; }
        public string CardId { get; set; }
    }
}
