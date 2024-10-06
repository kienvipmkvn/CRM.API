using CRM.Domain;

namespace CRM.Infastructure
{
    public interface IExternalCRMService
    {
        Task<bool> RegistPriceAgreement(PricingAgreementDTO pricingAgreement);
    }
}