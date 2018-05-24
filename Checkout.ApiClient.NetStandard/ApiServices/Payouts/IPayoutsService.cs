using Checkout.ApiServices.Payouts.RequestModels;
using Checkout.ApiServices.Payouts.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Payouts
{
    public interface IPayoutsService
    {
        HttpResponse<Payout> MakePayout(BasePayout requestModel);
    }
}