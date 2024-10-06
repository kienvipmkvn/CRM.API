using CRM.Application;
using CRM.Infastructure;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    public class PIMController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;
        public PIMController(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        [Route("pricing-agreement")]
        public async Task<IActionResult> RegisterPricingAgreement([FromBody] PricingAgreementDTO pricingAgreement)
        {
            await _publisher.Publish(pricingAgreement);
            return Ok();
        }
    }
}
