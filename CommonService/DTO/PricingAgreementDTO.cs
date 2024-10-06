namespace CRM.Infastructure
{
    public class PricingAgreementDTO
    {
        public string CustomerCode { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
