using CommonModel;
using CRMDbContext;
using CRMDbContext.Model;
using MediatR;

namespace CRM.API.MediatR
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, int>
    {
        private readonly CRMContext _dbContext;
        public CreateLeadCommandHandler(CRMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = new Lead()
            {
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
            };
            _dbContext.Leads.Add(lead);
            await _dbContext.SaveChangesAsync();
            return lead.Id;
        }
    }
}
