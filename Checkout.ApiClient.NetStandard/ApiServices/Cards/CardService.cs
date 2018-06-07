using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Cards.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Cards
{
    public class CardService : ICardService
    {
        private ICardServiceAsync _cardServiceAsync;
      
        public CardService(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _cardServiceAsync = new CardServiceAsync(apiHttpclient, configuration);
        }

        public HttpResponse<Card> CreateCard(string customerId, CardCreate requestModel)
        {
            return _cardServiceAsync.CreateCardAsync(customerId, requestModel).Result;
        }

        public HttpResponse<Card> CreateCard(string customerId, string cardToken)
        {
            return _cardServiceAsync.CreateCardAsync(customerId, cardToken).Result;
        }

        public HttpResponse<Card> GetCard(string customerId, string cardId)
        {
            return _cardServiceAsync.GetCardAsync(customerId, cardId).Result;
        }

        public HttpResponse<OkResponse> UpdateCard(string customerId, string cardId, CardUpdate requestModel)
        {
            return _cardServiceAsync.UpdateCardAsync(customerId, cardId, requestModel).Result;
        }

        public HttpResponse<OkResponse> DeleteCard(string customerId, string cardId)
        {
            return _cardServiceAsync.DeleteCardAsync(customerId, cardId).Result;
        }

        public HttpResponse<CardList> GetCardList(string customerId)
        {
            return _cardServiceAsync.GetCardListAsync(customerId).Result;
        }
    }

    public class CardServiceAsync : ICardServiceAsync
    {
        private IApiHttpClient _apiHttpClient;
        private CheckoutConfiguration _configuration;
        public CardServiceAsync(IApiHttpClient apiHttpclient, CheckoutConfiguration configuration)
        {
            _apiHttpClient = apiHttpclient;
            _configuration = configuration;
        }

        public Task<HttpResponse<Card>> CreateCardAsync(string customerId, CardCreate requestModel)
        {
            var createCardUri = string.Format(_configuration.ApiUrls.Cards, customerId);
            return _apiHttpClient.PostRequest<Card>(createCardUri, _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<Card>> CreateCardAsync(string customerId, string cardToken)
        {
            object token = new { token = cardToken };
            var createCardUri = string.Format(_configuration.ApiUrls.Cards, customerId);
            return _apiHttpClient.PostRequest<Card>(createCardUri, _configuration.SecretKey, token);
        }

        public Task<HttpResponse<Card>> GetCardAsync(string customerId, string cardId)
        {
            var getCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.GetRequest<Card>(getCardUri, _configuration.SecretKey);
        }

        public Task<HttpResponse<OkResponse>> UpdateCardAsync(string customerId, string cardId, CardUpdate requestModel)
        {
            var updateCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.PutRequest<OkResponse>(updateCardUri, _configuration.SecretKey, requestModel);
        }

        public Task<HttpResponse<OkResponse>> DeleteCardAsync(string customerId, string cardId)
        {
            var deleteCardUri = string.Format(_configuration.ApiUrls.Card, customerId, cardId);
            return _apiHttpClient.DeleteRequest<OkResponse>(deleteCardUri, _configuration.SecretKey);
        }

        public Task<HttpResponse<CardList>> GetCardListAsync(string customerId)
        {
            var getCardListUri = string.Format(_configuration.ApiUrls.Cards, customerId);
            return _apiHttpClient.GetRequest<CardList>(getCardListUri, _configuration.SecretKey);
        }
    }
}