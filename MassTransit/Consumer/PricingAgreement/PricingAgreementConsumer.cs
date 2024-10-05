using CommonModel;
using CommonService;
using MassTransit;

namespace CRM.API.MassTransit.Consumer
{
    public class PricingAgreementConsumer : IConsumer<PricingAgreementDTO>
    {
        private readonly ICRMService _cRMService;
        private readonly ILogger<PricingAgreementConsumer> _logger;
        public PricingAgreementConsumer(ICRMService cRMService, ILogger<PricingAgreementConsumer> logger)
        {
            _cRMService = cRMService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PricingAgreementDTO> context)
        {
            _logger.LogInformation("consuming by PricingAgreementConsumer: " + context.Message.ProductId);
            await _cRMService.RegistPriceAgreement(context.Message);
        }
    }
}
