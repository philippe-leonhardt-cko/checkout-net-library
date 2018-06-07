using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.Cards.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Threading.Tasks;

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

    public interface ICardServiceAsync
    {
        Task<HttpResponse<Card>> CreateCardAsync(string customerId, CardCreate requestModel);
        Task<HttpResponse<Card>> CreateCardAsync(string customerId, string cardToken);
        Task<HttpResponse<OkResponse>> DeleteCardAsync(string customerId, string cardId);
        Task<HttpResponse<Card>> GetCardAsync(string customerId, string cardId);
        Task<HttpResponse<CardList>> GetCardListAsync(string customerId);
        Task<HttpResponse<OkResponse>> UpdateCardAsync(string customerId, string cardId, CardUpdate requestModel);
    }
}