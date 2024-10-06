using CRM.Application;
using CRM.Domain;
using CRM.Infastructure;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WebhookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// register new (potential) customers into the system via the 'CRM API' through a webhook
        /// </summary>sender
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> RegisterLead([FromBody] CreateCustomerCommand customer)
        {
            var id = await _mediator.Send(customer);
            return Ok(id);
        }

        /// <summary>
        /// converted from a Lead to Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("lead/conversion")]
        public async Task<IActionResult> ConvertLeadToCustomer(LeadConvertedDTO leadConverted)
        {
            await _mediator.Send(new LeadConvertedCommand()
            {
                ConvertedDate = leadConverted.ConvertedDate,
                CustomerId = leadConverted.CustomerId,
                LeadId = leadConverted.LeadId,
            });
            return Ok();
        }

        [HttpPost]
        [Route("pricing-agreement")]
        public async Task<IActionResult> RegisterPricingAgreement([FromBody] PricingAgreementDTO pricingAgreement)
        {
            await _mediator.Send(new PricingAgreementCommand()
            {
                CustomerCode = pricingAgreement.CustomerCode,
                EffectiveDate = pricingAgreement.EffectiveDate,
                Price = pricingAgreement.Price,
                ProductId = pricingAgreement.ProductId
            });
            return Ok();
        }
    }
}
