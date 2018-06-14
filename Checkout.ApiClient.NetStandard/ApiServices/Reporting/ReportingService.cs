using Checkout.ApiServices.Reporting.RequestModels;
using Checkout.ApiServices.Reporting.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Reporting
{
    public class ReportingService : IReportingService
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public ReportingService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }
        /// <summary>
        /// Search for a customer’s transaction by a date range and then drill down using further filters.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<QueryTransactionResponse> QueryTransaction(QueryRequest requestModel)
        {
            return _apiHttpClient.PostRequest<QueryTransactionResponse>(_configuration.ApiUrls.ReportingTransactions, _configuration.SecretKey, requestModel);
        }

        /// <summary>
        /// Search for a customer’s chargebacks by a date range and then drill down using further filters.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel)
        {
            return _apiHttpClient.PostRequest<QueryChargebackResponse>(_configuration.ApiUrls.ReportingChargebacks, _configuration.SecretKey, requestModel);
        }
    }
}
