using Checkout.ApiServices.SharedModels;
using System.Collections.Generic;
using Checkout.ApiServices.RecurringPayments.RequestModels;

namespace Checkout.ApiServices.Charges.RequestModels
{
    public class DefaultCardCharge : BaseCharge
    {
        public bool AttemptN3D { get; set; } = true;
        public bool CardOnFile { get; set; }
        public string PreviousChargeId { get; set; }
        public List<CustomerPaymentPlanCreate> PaymentPlans { get; set; }
        public RecipientDetails RecipientDetails { get; set; }
        public string TransactionIndicator { get; set; }

    }
}
