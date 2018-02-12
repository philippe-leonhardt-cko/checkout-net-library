using Checkout.ApiServices.Customers.RequestModels;
using Checkout.ApiServices.Customers.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.Utilities;
using System;

namespace Checkout.ApiServices.Customers

{
    public class CustomerService
    {
        private ApiHttpClient _apiHttpClient;
        private AppSettings _appSettings;
        public CustomerService(ApiHttpClient apiHttpclient, AppSettings appSettings)
        {
            _apiHttpClient = apiHttpclient;
            _appSettings = appSettings;
        }

        public HttpResponse<Customer> CreateCustomer(CustomerCreate requestModel)
        {

            return _apiHttpClient.PostRequest<Customer>(_appSettings.ApiUrls.Customers, _appSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdateCustomer(string customerId, CustomerUpdate requestModel)
        {
            var updateCustomerUri = string.Format(_appSettings.ApiUrls.Customer, customerId);
            return _apiHttpClient.PutRequest<OkResponse>(updateCustomerUri, _appSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteCustomer(string customerId)
        {
            var deleteCustomerUri = string.Format(_appSettings.ApiUrls.Customer, customerId);
            return _apiHttpClient.DeleteRequest<OkResponse>(deleteCustomerUri, _appSettings.SecretKey);
        }

        public HttpResponse<Customer> GetCustomer(string customerId)
        {
            var getCustomerUri = string.Format(_appSettings.ApiUrls.Customer, customerId);
            return _apiHttpClient.GetRequest<Customer>(getCustomerUri, _appSettings.SecretKey);
        }

        public HttpResponse<CustomerList> GetCustomerList(CustomerGetList request)
        {
            var getCustomerListUri = _appSettings.ApiUrls.Customers;

            if (request.Count.HasValue)
            {
                getCustomerListUri = UrlHelper.AddParameterToUrl(getCustomerListUri, "count", request.Count.ToString());
            }

            if (request.Offset.HasValue)
            {
                getCustomerListUri = UrlHelper.AddParameterToUrl(getCustomerListUri, "offset", request.Offset.ToString());
            }

            if (request.FromDate.HasValue)
            {
                getCustomerListUri = UrlHelper.AddParameterToUrl(getCustomerListUri, "fromDate", DateTimeHelper.FormatAsUtc(request.FromDate.Value));
            }

            if (request.ToDate.HasValue)
            {
                getCustomerListUri = UrlHelper.AddParameterToUrl(getCustomerListUri, "toDate", DateTimeHelper.FormatAsUtc(request.ToDate.Value));
            }

            return _apiHttpClient.GetRequest<CustomerList>(getCustomerListUri, _appSettings.SecretKey);
        }
    }

}