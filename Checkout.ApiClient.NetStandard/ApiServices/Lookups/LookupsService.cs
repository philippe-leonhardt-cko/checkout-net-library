using Checkout.ApiServices.Lookups.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Lookups
{
    public class LookupsService : ILookupsService
    {
        private ILookupsServiceAsync _lookupsServiceAsync;

        public LookupsService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _lookupsServiceAsync = new LookupsServiceAsync(apiHttpclient, configuration);
        }
        public HttpResponse<CountryInfo> GetBinLookup(string bin)
        {
            return _lookupsServiceAsync.GetBinLookupAsync(bin).Result;
        }

        public HttpResponse<LocalPaymentData> GetLocalPaymentIssuerIds(string lppId)
        {
            return _lookupsServiceAsync.GetLocalPaymentIssuerIdsAsync(lppId).Result;
        }
    }

    public class LookupsServiceAsync : ILookupsServiceAsync
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public LookupsServiceAsync(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }
        public Task<HttpResponse<CountryInfo>> GetBinLookupAsync(string bin)
        {
            var uri = string.Format(_configuration.ApiUrls.BinLookup, bin);
            return _apiHttpClient.GetRequest<CountryInfo>(uri, _configuration.SecretKey);
        }

        public Task<HttpResponse<LocalPaymentData>> GetLocalPaymentIssuerIdsAsync(string lppId)
        {
            var uri = string.Format(_configuration.ApiUrls.LocalPaymentIssuerIdLookup, lppId);
            return _apiHttpClient.GetRequest<LocalPaymentData>(uri, _configuration.SecretKey);
        }
    }
}
