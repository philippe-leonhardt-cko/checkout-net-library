using System.Runtime.CompilerServices;
using Checkout.ApiServices.SharedModels;

namespace Checkout
{
    public interface IApiHttpClient
    {
        HttpResponse<T> DeleteRequest<T>(string requestUri, string authenticationKey, [CallerMemberName] string callerFunction = "");
        HttpResponse<T> GetRequest<T>(string requestUri, string authenticationKey, [CallerMemberName] string callerFunction = "");
        HttpResponse<T> PostRequest<T>(string requestUri, string authenticationKey, object requestPayload = null, [CallerMemberName] string callerFunction = "");
        HttpResponse<T> PutRequest<T>(string requestUri, string authenticationKey, object requestPayload = null, [CallerMemberName] string callerFunction = "");
    }
}