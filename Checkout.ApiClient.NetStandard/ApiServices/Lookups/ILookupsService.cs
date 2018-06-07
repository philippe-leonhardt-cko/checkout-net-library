using Checkout.ApiServices.Lookups.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Lookups
{
    public interface ILookupsService
    {
        HttpResponse<CountryInfo> GetBinLookup(string bin);
        HttpResponse<LocalPaymentData> GetLocalPaymentIssuerIds(string lppId);
    }

    public interface ILookupsServiceAsync
    {
        Task<HttpResponse<CountryInfo>> GetBinLookupAsync(string bin);
        Task<HttpResponse<LocalPaymentData>> GetLocalPaymentIssuerIdsAsync(string lppId);
    }
}