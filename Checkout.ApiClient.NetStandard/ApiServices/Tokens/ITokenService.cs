using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;

namespace Checkout.ApiServices.Tokens
{
    public interface ITokenService
    {
        HttpResponse<PaymentToken> CreatePaymentToken(PaymentTokenCreate requestModel);
        HttpResponse<CardTokenResponse> CreateVisaCheckoutCardToken(VisaCheckoutTokenCreate requestModel);
        /// <summary>
        ///     <para>Do not use the <c>GetCardTokenAsync</c> method in live production.</para>
        ///     <para>The cardToken is part of the response when you use Checkout.com solutions like Checkout.js and Frames in your shop.</para>
        /// </summary>
        HttpResponse<CardTokenCreate> GetCardToken(TokenCard requestModel);
        HttpResponse<OkResponse> UpdatePaymentToken(string paymentToken, PaymentTokenUpdate requestModel);
    }
}