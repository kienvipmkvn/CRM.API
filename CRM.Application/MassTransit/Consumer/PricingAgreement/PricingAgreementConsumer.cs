using CRM.Infastructure;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CRM.Application
{
    public class PricingAgreementConsumer : IConsumer<PricingAgreementDTO>
    {
        private readonly IExternalCRMService _cRMService;
        private readonly ILogger<PricingAgreementConsumer> _logger;
        public PricingAgreementConsumer(IExternalCRMService cRMService, ILogger<PricingAgreementConsumer> logger)
        {
            _cRMService = cRMService;
            _logger = logger;
        }

        //consume when the PIM API create new pricing agreement
        public async Task Consume(ConsumeContext<PricingAgreementDTO> context)
        {
            _logger.LogInformation("consuming by PricingAgreementConsumer: " + context.Message.ProductId);

            //send an API request to the CRM system to regist new pricing agreement
            await _cRMService.RegistPriceAgreement(context.Message);
        }
    }
}
