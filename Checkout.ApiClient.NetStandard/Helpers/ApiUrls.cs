namespace Checkout
{
    public class ApiUrls
    {
        private AppSettings _appSettings;

        public ApiUrls(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string Charges
            => string.Concat(_appSettings.BaseApiUri, "/charges");

        public string Charge
            => string.Concat(_appSettings.BaseApiUri, "/charges/{0}");

        public string ChargeHistory
            => string.Concat(_appSettings.BaseApiUri, "/charges/{0}/history");

        public string CaptureCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/{0}/capture");

        public string RefundCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/{0}/refund");

        public string VoidCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/{0}/void");

        public string DefaultCardCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/customer");

        public string LocalPaymentCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/localpayment");

        public string CardTokenCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/token");

        public string CardCharge
            => string.Concat(_appSettings.BaseApiUri, "/charges/card");

        public string CardToken
            => string.Concat(_appSettings.BaseApiUri, "/tokens/card");

        public string PaymentToken
            => string.Concat(_appSettings.BaseApiUri, "/tokens/payment");

        public string UpdatePaymentToken
            => string.Concat(_appSettings.BaseApiUri, "/tokens/payment/{0}");

        public string VisaCheckout
            => string.Concat(_appSettings.BaseApiUri, "/tokens/card/visa-checkout");

        public string Customers
            => string.Concat(_appSettings.BaseApiUri, "/customers");

        public string Customer
            => string.Concat(_appSettings.BaseApiUri, "/customers/{0}");

        public string CustomerViaEmail
            => string.Concat(_appSettings.BaseApiUri, "/customers?email={0}");

        public string Cards
            => string.Concat(_appSettings.BaseApiUri, "/customers/{0}/cards");

        public string Card
            => string.Concat(_appSettings.BaseApiUri, "/customers/{0}/cards/{1}");

        public string ReportingTransactions
            => string.Concat(_appSettings.BaseApiUri, "/reporting/transactions");

        public string ReportingChargebacks
            => string.Concat(_appSettings.BaseApiUri, "/reporting/chargebacks");

        public string BinLookup
            => string.Concat(_appSettings.BaseApiUri, "/lookups/bins/{0}");

        public string LocalPaymentIssuerIdLookup
            => string.Concat(_appSettings.BaseApiUri, "/lookups/localpayments/{0}/tags/issuerid");

        public string RecurringPaymentPlans
            => string.Concat(_appSettings.BaseApiUri, "/recurringPayments/plans");

        public string RecurringPaymentPlan
            => string.Concat(_appSettings.BaseApiUri, "/recurringPayments/plans/{0}");

        public string RecurringPaymentPlanSearch
            => string.Concat(_appSettings.BaseApiUri, "/recurringPayments/plans/search");

        public string RecurringCustomerPaymentPlanSearch
            => string.Concat(_appSettings.BaseApiUri, "/recurringPayments/customers/search");

        public string RecurringCustomerPaymentPlan
            => string.Concat(_appSettings.BaseApiUri, "/recurringPayments/customers/{0}");
    }
}