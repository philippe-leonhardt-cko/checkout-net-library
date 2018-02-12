using Checkout.ApiServices.Cards;
using Checkout.ApiServices.Charges;
using Checkout.ApiServices.Customers;
using Checkout.ApiServices.Lookups;
using Checkout.ApiServices.Reporting;
using Checkout.ApiServices.RecurringPayments;
using Checkout.ApiServices.Tokens;
using Checkout.Helpers;

namespace Checkout
{
    public sealed class APIClient
    {
        private AppSettings _appSettings;
        private ApiHttpClient _apiHttpClient;
        private CardService _cardService;
        private ChargeService _chargeService;
        private CustomerService _customerService;
        private LookupsService _lookupsService;
        private RecurringPaymentsService _recurringPaymentsService;
        private ReportingService _reportingService;
        private TokenService _tokenService;

        public AppSettings AppSettings { get { return _appSettings ?? (_appSettings = AppConfiguration.Sandbox()); } set { AppSettings _appSettings = value; } }
        public ApiHttpClient ApiHttpClient { get { return _apiHttpClient ?? (_apiHttpClient = new ApiHttpClient(AppSettings)); } }
        public CardService CardService { get { return _cardService ?? (_cardService = new CardService(ApiHttpClient, AppSettings)); } }
        public ChargeService ChargeService { get { return _chargeService ?? (_chargeService = new ChargeService(ApiHttpClient, AppSettings)); } }
        public CustomerService CustomerService { get { return _customerService ?? (_customerService = new CustomerService(ApiHttpClient, AppSettings)); } }
        public LookupsService LookupsService { get { return _lookupsService ?? (_lookupsService = new LookupsService(ApiHttpClient, AppSettings)); } }
        public RecurringPaymentsService RecurringPaymentsService { get { return _recurringPaymentsService ?? (_recurringPaymentsService = new RecurringPaymentsService(ApiHttpClient, AppSettings)); } }
        public ReportingService ReportingService { get { return _reportingService ?? (_reportingService = new ReportingService(ApiHttpClient, AppSettings)); } }
        public TokenService TokenService { get { return _tokenService ?? (_tokenService = new TokenService(ApiHttpClient, AppSettings)); } }

#if (NET40 || NET45)
        public APIClient()
        {
            if (AppSettings.Environment == Environment.Undefined)
            {
                AppSettings.SetEnvironmentFromConfig();
            }

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
        public APIClient(AppConfiguration appConfig)
        {
            AppSettings = appConfig;
            ContentAdaptor.Setup();
        }
#endif
    }
}
