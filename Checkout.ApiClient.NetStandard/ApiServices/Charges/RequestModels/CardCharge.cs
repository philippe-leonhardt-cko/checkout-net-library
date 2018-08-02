using System.Collections.Generic;
using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.RecurringPayments.RequestModels;

namespace Checkout.ApiServices.Charges.RequestModels
{
    public class CardCharge : DefaultCardCharge
    {
        public CardCreate Card { get; set; }
    }
}
