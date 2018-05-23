using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Cards.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Cards
{
    public class CardService
    {
        private ApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public CardService(ApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }

        public HttpResponse<Card> CreateCard(string customerId, CardCreate requestModel)
        {
            var createCardUri = string.Format(_configuration.ApiUrls.Cards, customerId);
            return _apiHttpClient.PostRequest<Card>(createCardUri, _configuration.SecretKey, requestModel);
        }

        public HttpResponse<Card> GetCard(string customerId, string cardId)
        {
            var getCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.GetRequest<Card>(getCardUri, _configuration.SecretKey);
        }

        public HttpResponse<OkResponse> UpdateCard(string customerId, string cardId, CardUpdate requestModel)
        {
            var updateCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.PutRequest<OkResponse>(updateCardUri, _configuration.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteCard(string customerId, string cardId)
        {
            var deleteCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.DeleteRequest<OkResponse>(deleteCardUri, _configuration.SecretKey);
        }

        public HttpResponse<CardList> GetCardList(string customerId)
        {
            var getCardListUri = string.Format(_configuration.ApiUrls.Cards, customerId);
            return _apiHttpClient.GetRequest<CardList>(getCardListUri, _configuration.SecretKey);
        }

    }
}