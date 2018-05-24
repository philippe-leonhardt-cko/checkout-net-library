using Checkout.ApiServices.Cards;
using Checkout.ApiServices.Charges;
using Checkout.ApiServices.Customers;
using Checkout.ApiServices.Lookups;
using Checkout.ApiServices.Payouts;
using Checkout.ApiServices.Reporting;
using Checkout.ApiServices.RecurringPayments;
using Checkout.ApiServices.Tokens;
using Checkout.Helpers;

namespace Checkout
{
    public sealed class ApiClient
    {
        public CheckoutConfiguration CheckoutConfiguration { get; private set; }
        public IApiHttpClient ApiHttpClient { get; private set; }

        public CardService CardService { get; private set; }
        public ChargeService ChargeService { get; private set; }
        public CustomerService CustomerService { get; private set; }
        public LookupsService LookupsService { get; private set; }
        public PayoutsService PayoutsService { get; private set; }
        public RecurringPaymentsService RecurringPaymentsService { get; private set; }
        public ReportingService ReportingService { get; private set; }
        public TokenService TokenService { get; private set; }

        public ApiClient(CheckoutConfiguration configuration)
        {
            CheckoutConfiguration = configuration;

            ApiHttpClient = new ApiHttpClient(CheckoutConfiguration);
            CardService = new CardService(ApiHttpClient, CheckoutConfiguration);
            ChargeService = new ChargeService(ApiHttpClient, CheckoutConfiguration);
            CustomerService = new CustomerService(ApiHttpClient, CheckoutConfiguration);
            LookupsService = new LookupsService(ApiHttpClient, CheckoutConfiguration);
            PayoutsService = new PayoutsService(ApiHttpClient, CheckoutConfiguration);
            RecurringPaymentsService = new RecurringPaymentsService(ApiHttpClient, CheckoutConfiguration);
            ReportingService = new ReportingService(ApiHttpClient, CheckoutConfiguration);
            TokenService = new TokenService(ApiHttpClient, CheckoutConfiguration);

            ContentAdaptor.Setup();
        }

        public ApiClient(CheckoutConfiguration configuration, IApiHttpClient httpClient)
        {
            CheckoutConfiguration = configuration;

            ApiHttpClient = httpClient;
            CardService = new CardService(ApiHttpClient, CheckoutConfiguration);
            ChargeService = new ChargeService(ApiHttpClient, CheckoutConfiguration);
            CustomerService = new CustomerService(ApiHttpClient, CheckoutConfiguration);
            LookupsService = new LookupsService(ApiHttpClient, CheckoutConfiguration);
            PayoutsService = new PayoutsService(ApiHttpClient, CheckoutConfiguration);
            RecurringPaymentsService = new RecurringPaymentsService(ApiHttpClient, CheckoutConfiguration);
            ReportingService = new ReportingService(ApiHttpClient, CheckoutConfiguration);
            TokenService = new TokenService(ApiHttpClient, CheckoutConfiguration);

            ContentAdaptor.Setup();
        }
    }
}
