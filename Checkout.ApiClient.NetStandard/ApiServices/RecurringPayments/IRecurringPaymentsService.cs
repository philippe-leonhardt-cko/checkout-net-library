using Checkout.ApiServices.RecurringPayments.RequestModels;
using Checkout.ApiServices.RecurringPayments.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.RecurringPayments
{
    public interface IRecurringPaymentsService
    {
        HttpResponse<OkResponse> CancelCustomerPaymentPlan(string customerPlanId);
        HttpResponse<OkResponse> CancelPaymentPlan(string planId);
        HttpResponse<SinglePaymentPlanCreateResponse> CreatePaymentPlan(SinglePaymentPlanCreateRequest requestModel);
        HttpResponse<CustomerPaymentPlan> GetCustomerPaymentPlan(string customerPlanId);
        HttpResponse<ResponsePaymentPlan> GetPaymentPlan(string planId);
        HttpResponse<QueryCustomerPaymentPlanResponse> QueryCustomerPaymentPlan(QueryCustomerPaymentPlanRequest requestModel);
        HttpResponse<QueryPaymentPlanResponse> QueryPaymentPlan(QueryPaymentPlanRequest requestModel);
        HttpResponse<OkResponse> UpdateCustomerPaymentPlan(string customerPlanId, CustomerPaymentPlanUpdate requestModel);
        HttpResponse<OkResponse> UpdatePaymentPlan(string planId, PaymentPlanUpdate requestModel);
    }

    public interface IRecurringPaymentsServiceAsync
    {
        Task<HttpResponse<OkResponse>> CancelCustomerPaymentPlanAsync(string customerPlanId);
        Task<HttpResponse<OkResponse>> CancelPaymentPlanAsync(string planId);
        Task<HttpResponse<SinglePaymentPlanCreateResponse>> CreatePaymentPlanAsync(SinglePaymentPlanCreateRequest requestModel);
        Task<HttpResponse<CustomerPaymentPlan>> GetCustomerPaymentPlanAsync(string customerPlanId);
        Task<HttpResponse<ResponsePaymentPlan>> GetPaymentPlanAsync(string planId);
        Task<HttpResponse<QueryCustomerPaymentPlanResponse>> QueryCustomerPaymentPlanAsync(QueryCustomerPaymentPlanRequest requestModel);
        Task<HttpResponse<QueryPaymentPlanResponse>> QueryPaymentPlanAsync(QueryPaymentPlanRequest requestModel);
        Task<HttpResponse<OkResponse>> UpdateCustomerPaymentPlanAsync(string customerPlanId, CustomerPaymentPlanUpdate requestModel);
        Task<HttpResponse<OkResponse>> UpdatePaymentPlanAsync(string planId, PaymentPlanUpdate requestModel);
    }
}