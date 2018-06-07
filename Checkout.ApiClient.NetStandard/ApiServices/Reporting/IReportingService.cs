using Checkout.ApiServices.Reporting.RequestModels;
using Checkout.ApiServices.Reporting.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Reporting
{
    public interface IReportingService
    {
        HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel);
        HttpResponse<QueryTransactionResponse> QueryTransaction(QueryRequest requestModel);
    }

    public interface IReportingServiceAsync
    {
        Task<HttpResponse<QueryChargebackResponse>> QueryChargebackAsync(QueryRequest requestModel);
        Task<HttpResponse<QueryTransactionResponse>> QueryTransactionAsync(QueryRequest requestModel);
    }
}