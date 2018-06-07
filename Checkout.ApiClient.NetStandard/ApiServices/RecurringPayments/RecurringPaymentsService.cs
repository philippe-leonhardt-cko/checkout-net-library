using Checkout.ApiServices.RecurringPayments.RequestModels;
using Checkout.ApiServices.RecurringPayments.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.RecurringPayments
{
    public class RecurringPaymentsService : IRecurringPaymentsService
    {
        private IRecurringPaymentsServiceAsync _recurringPaymentsServiceAsync;

        public RecurringPaymentsService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _recurringPaymentsServiceAsync = new RecurringPaymentsServiceAsync(apiHttpclient, configuration);
        }

        public HttpResponse<SinglePaymentPlanCreateResponse> CreatePaymentPlan(SinglePaymentPlanCreateRequest requestModel)
        {
            return _recurringPaymentsServiceAsync.CreatePaymentPlanAsync(requestModel).Result;
        }

        public HttpResponse<OkResponse> UpdatePaymentPlan(string planId, PaymentPlanUpdate requestModel)
        {
            return _recurringPaymentsServiceAsync.UpdatePaymentPlanAsync(planId, requestModel).Result;
        }

        public HttpResponse<OkResponse> CancelPaymentPlan(string planId)
        {
            return _recurringPaymentsServiceAsync.CancelPaymentPlanAsync(planId).Result;
        }

        public HttpResponse<ResponsePaymentPlan> GetPaymentPlan(string planId)
        {
            return _recurringPaymentsServiceAsync.GetPaymentPlanAsync(planId).Result;
        }

        public HttpResponse<QueryPaymentPlanResponse> QueryPaymentPlan(QueryPaymentPlanRequest requestModel)
        {
            return _recurringPaymentsServiceAsync.QueryPaymentPlanAsync(requestModel).Result;
        }

        public HttpResponse<QueryCustomerPaymentPlanResponse> QueryCustomerPaymentPlan(QueryCustomerPaymentPlanRequest requestModel)
        {
            return _recurringPaymentsServiceAsync.QueryCustomerPaymentPlanAsync(requestModel).Result;
        }

        public HttpResponse<CustomerPaymentPlan> GetCustomerPaymentPlan(string customerPlanId)
        {
            return _recurringPaymentsServiceAsync.GetCustomerPaymentPlanAsync(customerPlanId).Result;
        }

        public HttpResponse<OkResponse> CancelCustomerPaymentPlan(string customerPlanId)
        {
            return _recurringPaymentsServiceAsync.CancelCustomerPaymentPlanAsync(customerPlanId).Result;
        }

        public HttpResponse<OkResponse> UpdateCustomerPaymentPlan(string customerPlanId, CustomerPaymentPlanUpdate requestModel)
        {
            return _recurringPaymentsServiceAsync.UpdateCustomerPaymentPlanAsync(customerPlanId, requestModel).Result;
        }
    }

    public class RecurringPaymentsServiceAsync : IRecurringPaymentsServiceAsync
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public RecurringPaymentsServiceAsync(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }

        public Task<HttpResponse<SinglePaymentPlanCreateResponse>> CreatePaymentPlanAsync(SinglePaymentPlanCreateRequest requestModel)
        {
            return _apiHttpClient.PostRequest<SinglePaymentPlanCreateResponse>(_configuration.ApiUrls.RecurringPaymentPlans, _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<OkResponse>> UpdatePaymentPlanAsync(string planId, PaymentPlanUpdate requestModel)
        {
            return _apiHttpClient.PutRequest<OkResponse>(string.Format(_configuration.ApiUrls.RecurringPaymentPlan, planId), _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<OkResponse>> CancelPaymentPlanAsync(string planId)
        {
            return _apiHttpClient.DeleteRequest<OkResponse>(string.Format(_configuration.ApiUrls.RecurringPaymentPlan, planId), _configuration.SecretKey);
        }

        public Task<HttpResponse<ResponsePaymentPlan>> GetPaymentPlanAsync(string planId)
        {
            return _apiHttpClient.GetRequest<ResponsePaymentPlan>(string.Format(_configuration.ApiUrls.RecurringPaymentPlan, planId), _configuration.SecretKey);
        }

        public Task<HttpResponse<QueryPaymentPlanResponse>> QueryPaymentPlanAsync(QueryPaymentPlanRequest requestModel)
        {
            return _apiHttpClient.PostRequest<QueryPaymentPlanResponse>(_configuration.ApiUrls.RecurringPaymentPlanSearch, _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<QueryCustomerPaymentPlanResponse>> QueryCustomerPaymentPlanAsync(QueryCustomerPaymentPlanRequest requestModel)
        {
            return _apiHttpClient.PostRequest<QueryCustomerPaymentPlanResponse>(_configuration.ApiUrls.RecurringCustomerPaymentPlanSearch, _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<CustomerPaymentPlan>> GetCustomerPaymentPlanAsync(string customerPlanId)
        {
            return _apiHttpClient.GetRequest<CustomerPaymentPlan>(string.Format(_configuration.ApiUrls.RecurringCustomerPaymentPlan, customerPlanId), _configuration.SecretKey);
        }

        public Task<HttpResponse<OkResponse>> CancelCustomerPaymentPlanAsync(string customerPlanId)
        {
            return _apiHttpClient.DeleteRequest<OkResponse>(string.Format(_configuration.ApiUrls.RecurringCustomerPaymentPlan, customerPlanId), _configuration.SecretKey);
        }

        public Task<HttpResponse<OkResponse>> UpdateCustomerPaymentPlanAsync(string customerPlanId, CustomerPaymentPlanUpdate requestModel)
        {
            return _apiHttpClient.PutRequest<OkResponse>(string.Format(_configuration.ApiUrls.RecurringCustomerPaymentPlan, customerPlanId), _configuration.SecretKey, requestModel);
        }
    }
}
