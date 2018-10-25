using Checkout.ApiServices.Charges.RequestModels;
using Checkout.ApiServices.Charges.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Charges
{
    public interface IChargeService
    {
        HttpResponse<Capture> CaptureCharge(string chargeId, ChargeCapture requestModel);
        HttpResponse<Charge> ChargeWithCard(CardCharge requestModel);
        HttpResponse<Charge> ChargeWithCardId(CardIdCharge requestModel);
        HttpResponse<Charge> ChargeWithCardToken(CardTokenCharge requestModel);
        HttpResponse<Charge> ChargeWithDefaultCustomerCard(DefaultCardCharge requestModel);
        HttpResponse<Charge> ChargeWithLocalPayment(LocalPaymentCharge requestModel);
        HttpResponse<Charge> GetCharge(string chargeId);
        HttpResponse<ChargeHistory> GetChargeHistory(string chargeId);
        HttpResponse<Refund> RefundCharge(string chargeId, ChargeRefund requestModel);
        HttpResponse<OkResponse> UpdateCharge(string chargeId, ChargeUpdate requestModel);
        HttpResponse<Charge> VerifyCharge(string paymentToken);
        HttpResponse<Void> VoidCharge(string chargeId, ChargeVoid requestModel);
    }
}