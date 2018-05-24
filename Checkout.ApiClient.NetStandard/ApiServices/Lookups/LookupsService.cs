using Checkout.ApiServices.Lookups.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Lookups
{
    public class LookupsService
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public LookupsService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }
        public HttpResponse<CountryInfo> GetBinLookup(string bin)
        {
            var uri = string.Format(_configuration.ApiUrls.BinLookup, bin);
            return _apiHttpClient.GetRequest<CountryInfo>(uri, _configuration.SecretKey);
        }

        public HttpResponse<LocalPaymentData> GetLocalPaymentIssuerIds(string lppId)
        {
            var uri = string.Format(_configuration.ApiUrls.LocalPaymentIssuerIdLookup, lppId);
            return _apiHttpClient.GetRequest<LocalPaymentData>(uri, _configuration.SecretKey);
        }
    }
}
