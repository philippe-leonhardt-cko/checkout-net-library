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
    public sealed class APIClient
    {
        public AppSettings AppSettings { get; private set; }
        public ApiHttpClient ApiHttpClient { get; private set; }

        public CardService CardService { get; private set; }
        public ChargeService ChargeService { get; private set; }
        public CustomerService CustomerService { get; private set; }
        public LookupsService LookupsService { get; private set; }
        public PayoutsService PayoutsService { get; private set; }
        public RecurringPaymentsService RecurringPaymentsService { get; private set; }
        public ReportingService ReportingService { get; private set; }
        public TokenService TokenService { get; private set; }


#if (NET40 || NET45)
        public APIClient()
        {
            AppSettings = new AppSettings();
            if (AppSettings.Environment == Environment.Undefined)
            {
                AppSettings.SetEnvironmentFromConfig();
            }

            ApiHttpClient = new ApiHttpClient(AppSettings);
            CardService = new CardService(ApiHttpClient, AppSettings);
            ChargeService = new ChargeService(ApiHttpClient, AppSettings);
            CustomerService = new CustomerService(ApiHttpClient, AppSettings);
            LookupsService = new LookupsService(ApiHttpClient, AppSettings);
            PayoutsService = new PayoutsService(ApiHttpClient, AppSettings);
            RecurringPaymentsService = new RecurringPaymentsService(ApiHttpClient, AppSettings);
            ReportingService = new ReportingService(ApiHttpClient, AppSettings);
            TokenService = new TokenService(ApiHttpClient, AppSettings);

            ContentAdaptor.Setup();
        }

        public APIClient(string secretKey, Environment env, bool debugMode, int connectTimeout)
            : this(secretKey, env, debugMode)
        {
            AppSettings.RequestTimeout = connectTimeout;
        }

        public APIClient(string secretKey, Environment env, bool debugMode)
            : this(secretKey, env)
        {
            AppSettings.DebugMode = debugMode;
        }

        public APIClient(string secretKey, Environment env)
        {
            AppSettings.SecretKey = secretKey;
            AppSettings.Environment = env;
            ContentAdaptor.Setup();
        }

        public APIClient(string secretKey, bool debugMode)
            : this(secretKey)
        {
            AppSettings.DebugMode = debugMode;
        }

        public APIClient(string secretKey)
            : this()
        {
            AppSettings.SecretKey = secretKey;
        }
#elif (NETSTANDARD)
        public APIClient(AppSettings appSettings)
        {
            AppSettings = appSettings;

            ApiHttpClient = new ApiHttpClient(AppSettings);
            CardService = new CardService(ApiHttpClient, AppSettings);
            ChargeService = new ChargeService(ApiHttpClient, AppSettings);
            CustomerService = new CustomerService(ApiHttpClient, AppSettings);
            LookupsService = new LookupsService(ApiHttpClient, AppSettings);
            PayoutsService = new PayoutsService(ApiHttpClient, AppSettings);
            RecurringPaymentsService = new RecurringPaymentsService(ApiHttpClient, AppSettings);
            ReportingService = new ReportingService(ApiHttpClient, AppSettings);
            TokenService = new TokenService(ApiHttpClient, AppSettings);

            ContentAdaptor.Setup();
        }
#endif
    }
}
