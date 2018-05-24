using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;

namespace Checkout.ApiServices.Tokens
{
    public interface ITokenService
    {
        HttpResponse<PaymentToken> CreatePaymentToken(PaymentTokenCreate requestModel);
        HttpResponse<CardTokenResponse> CreateVisaCheckoutCardToken(VisaCheckoutTokenCreate requestModel);
        HttpResponse<CardTokenCreate> GetCardToken(TokenCard requestModel);
        HttpResponse<OkResponse> UpdatePaymentToken(string paymentToken, PaymentTokenUpdate requestModel);
    }
}