using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.Tokens.RequestModels;
using Checkout.ApiServices.Tokens.ResponseModels;

namespace Checkout.ApiServices.Tokens
{
    public class TokenService : ITokenService
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public TokenService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }
        public HttpResponse<PaymentToken> CreatePaymentToken(PaymentTokenCreate requestModel)
        {
            return _apiHttpClient.PostRequest<PaymentToken>(_configuration.ApiUrls.PaymentToken, _configuration.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdatePaymentToken(string paymentToken, PaymentTokenUpdate requestModel)
        {
            var updatePaymentTokenUri = string.Format(_configuration.ApiUrls.UpdatePaymentToken, paymentToken);
            return _apiHttpClient.PutRequest<OkResponse>(updatePaymentTokenUri, _configuration.SecretKey, requestModel);
        }

        public HttpResponse<CardTokenResponse> CreateVisaCheckoutCardToken(VisaCheckoutTokenCreate requestModel)
        {
            return _apiHttpClient.PostRequest<CardTokenResponse>(_configuration.ApiUrls.VisaCheckout, _configuration.PublicKey, requestModel);
        }

        public HttpResponse<CardTokenCreate> GetCardToken(TokenCard requestModel)
        {
            return _apiHttpClient.PostRequest<CardTokenCreate>(_configuration.ApiUrls.CardToken, _configuration.PublicKey, requestModel);
        }
    }
}
