using MediatR;

namespace CRM.Application
{
    public record CreateCustomerCommand(string Name, string Email, string PhoneNumber) : IRequest<int>
    {

    }
}
