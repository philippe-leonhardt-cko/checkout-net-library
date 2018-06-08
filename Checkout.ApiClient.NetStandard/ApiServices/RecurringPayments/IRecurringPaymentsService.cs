using Checkout.ApiServices.RecurringPayments.RequestModels;
using Checkout.ApiServices.RecurringPayments.ResponseModels;
using Checkout.ApiServices.SharedModels;

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
}