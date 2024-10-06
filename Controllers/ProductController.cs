using CRM.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}
