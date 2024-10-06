using MassTransit;
using MediatR;

namespace CRM.Application
{
    public class LeadConvertedCommandHandler : IRequestHandler<LeadConvertedCommand, bool>
    {
        private readonly IPublishEndpoint _publisher;

        public LeadConvertedCommandHandler(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public async Task<bool> Handle(LeadConvertedCommand request, CancellationToken cancellationToken)
        {
            await this._publisher.Publish(request, cancellationToken);
            return true;
        }
    }
}
