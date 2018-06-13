using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Tokens
{
    public interface ITokenServiceAsync
    {
        Task<HttpResponse<PaymentToken>> CreatePaymentTokenAsync(PaymentTokenCreate requestModel);
        Task<HttpResponse<CardTokenResponse>> CreateVisaCheckoutCardTokenAsync(VisaCheckoutTokenCreate requestModel);
        /// <summary>
        ///     <para>Do not use the <c>GetCardTokenAsync</c> method in live production.</para>
        ///     <para>The cardToken is part of the response when you use Checkout.com solutions like Checkout.js and Frames in your shop.</para>
        /// </summary>
        Task<HttpResponse<CardTokenCreate>> GetCardTokenAsync(TokenCard requestModel);
        Task<HttpResponse<OkResponse>> UpdatePaymentTokenAsync(string paymentToken, PaymentTokenUpdate requestModel);
    }
}