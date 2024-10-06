using CommonModel;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace PIM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingAgreementController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;

        public PricingAgreementController(IPublishEndpoint publisher)
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
