using Checkout.ApiServices.Reporting.RequestModels;
using Checkout.ApiServices.Reporting.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Reporting
{
    public interface IReportingService
    {
        HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel);
        HttpResponse<QueryTransactionResponse> QueryTransaction(QueryRequest requestModel);
    }
}