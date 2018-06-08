using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Cards.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Cards
{
    public interface ICardService
    {
        HttpResponse<Card> CreateCard(string customerId, CardCreate requestModel);
        HttpResponse<Card> CreateCard(string customerId, string cardToken);
        HttpResponse<OkResponse> DeleteCard(string customerId, string cardId);
        HttpResponse<Card> GetCard(string customerId, string cardId);
        HttpResponse<CardList> GetCardList(string customerId);
        HttpResponse<OkResponse> UpdateCard(string customerId, string cardId, CardUpdate requestModel);
    }
}