using Checkout.ApiServices.Customers.RequestModels;
using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Customers
{
    public interface ICustomerService
    {
        HttpResponse<Customer> CreateCustomer(CustomerCreate requestModel);
        HttpResponse<OkResponse> DeleteCustomer(string customerId);
        HttpResponse<Customer> GetCustomer(string identifier);
        HttpResponse<CustomerList> GetCustomerList(CustomerGetList request);
        HttpResponse<OkResponse> UpdateCustomer(string customerId, CustomerUpdate requestModel);
    }
}