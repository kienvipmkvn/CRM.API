using CRM.Domain;
using CRM.Infastructure;
using MediatR;

namespace CRM.Application
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, List<Product>>
    {
        private readonly IPIMService _pIMService;

        public GetProductsCommandHandler(IPIMService pIMService)
        {
            _pIMService = pIMService;
        }

        public async Task<List<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            return await _pIMService.GetProductsAsync();
        }
    }
}
