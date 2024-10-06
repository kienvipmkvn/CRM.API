using CRM.Domain;
using CRM.Infastructure;
using MediatR;

namespace CRM.Application
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly CRMDbContext _dbContext;
        public CreateLeadCommandHandler(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var lead = new Lead()
            {
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
            };
            _dbContext.Leads.Add(lead);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return lead.Id;
        }
    }
}
