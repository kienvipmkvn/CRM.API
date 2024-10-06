using CRM.Domain;
using MediatR;

namespace CRM.Application
{
    public class GetProductsCommand : IRequest<List<Product>>
    {

    }
}
