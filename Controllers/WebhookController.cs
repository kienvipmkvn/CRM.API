using CommonModel;
using CommonService;
using CRM.API.MassTransit;
using CRM.API.MediatR;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly IPIMService _pIMService;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publisher;

        public WebhookController(IPIMService pIMService, IMediator mediator, IPublishEndpoint publisher)
        {
            _pIMService = pIMService;
            _mediator = mediator;
            _publisher = publisher;
        }

        /// <summary>
        /// register new (potential) customers into the system via the 'CRM API' through a webhook
        /// </summary>sender
        /// <param name="lead"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("lead")]
        public async Task<IActionResult> RegisterLead([FromBody] CreateLeadCommand lead)
        {
            var id = await _mediator.Send(lead);
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
            var rs = await _pIMService.GetProductsAsync();
            return Ok(rs);
        }

        /// <summary>
        /// converted from a Lead to Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("customer/convert")]
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
