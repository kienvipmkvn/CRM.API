using MediatR;

namespace CRM.API.MediatR
{
    public record CreateLeadCommand(string Name, string Email, string PhoneNumber) : IRequest<int>
    {

    }
}
