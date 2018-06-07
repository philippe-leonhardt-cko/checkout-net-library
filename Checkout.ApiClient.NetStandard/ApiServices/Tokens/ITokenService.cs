using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Tokens
{
    public interface ITokenService
    {
        HttpResponse<PaymentToken> CreatePaymentToken(PaymentTokenCreate requestModel);
        HttpResponse<CardTokenResponse> CreateVisaCheckoutCardToken(VisaCheckoutTokenCreate requestModel);
        HttpResponse<CardTokenCreate> GetCardToken(TokenCard requestModel);
        HttpResponse<OkResponse> UpdatePaymentToken(string paymentToken, PaymentTokenUpdate requestModel);
    }

    public interface ITokenServiceAsync
    {
        Task<HttpResponse<PaymentToken>> CreatePaymentTokenAsync(PaymentTokenCreate requestModel);
        Task<HttpResponse<CardTokenResponse>> CreateVisaCheckoutCardTokenAsync(VisaCheckoutTokenCreate requestModel);
        Task<HttpResponse<CardTokenCreate>> GetCardTokenAsync(TokenCard requestModel);
        Task<HttpResponse<OkResponse>> UpdatePaymentTokenAsync(string paymentToken, PaymentTokenUpdate requestModel);
    }
}