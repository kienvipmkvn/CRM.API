using CRM.Application;
using CRM.Domain;
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
        private readonly IPublishEndpoint _publisher;

        public WebhookController(IMediator mediator, IPublishEndpoint publisher)
        {
            _mediator = mediator;
            _publisher = publisher;
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
        /// view the company's products and standard prices (these are internally exposed via the 'PIM API')
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            var rs = await _mediator.Send(new GetProductsCommand());
            return Ok(rs);
        }

        /// <summary>
        /// converted from a Lead to Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("lead/conversion")]
        public async Task<IActionResult> ConvertLeadToCustomer(LeadConvertedDTO leadConverted)
        {
            await _publisher.Publish(new LeadConvertedCommand()
            {
                ConvertedDate = leadConverted.ConvertedDate,
                CustomerId = leadConverted.CustomerId,
                LeadId = leadConverted.LeadId,
            });
            return Ok();
        }
    }
}
