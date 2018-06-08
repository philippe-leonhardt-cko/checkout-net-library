using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;

namespace Checkout.ApiServices.Tokens
{
    public class TokenService : ITokenService
    {
        private ITokenServiceAsync _tokenServiceAsync;

        public TokenService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _tokenServiceAsync = new TokenServiceAsync(apiHttpclient, configuration);
        }
        public HttpResponse<PaymentToken> CreatePaymentToken(PaymentTokenCreate requestModel)
        {
            return _tokenServiceAsync.CreatePaymentTokenAsync(requestModel).Result;
        }

        public HttpResponse<OkResponse> UpdatePaymentToken(string paymentToken, PaymentTokenUpdate requestModel)
        {
            return _tokenServiceAsync.UpdatePaymentTokenAsync(paymentToken, requestModel).Result;
        }

        public HttpResponse<CardTokenResponse> CreateVisaCheckoutCardToken(VisaCheckoutTokenCreate requestModel)
        {
            return _tokenServiceAsync.CreateVisaCheckoutCardTokenAsync(requestModel).Result;
        }

        // Do not use the GetCardToken() method in live production. The cardToken is part of the response when you Checkout.com solutions like Checkout.js and Frames in your shop.
        public HttpResponse<CardTokenCreate> GetCardToken(TokenCard requestModel)
        {
            return _tokenServiceAsync.GetCardTokenAsync(requestModel).Result;
        }
    }
}
