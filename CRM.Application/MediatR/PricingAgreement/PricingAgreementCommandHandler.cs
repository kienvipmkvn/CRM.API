using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.MediatR
{
    public class PricingAgreementCommandHandler : IRequestHandler<PricingAgreementCommand, bool>
    {
        private readonly IPublishEndpoint _publisher;

        public PricingAgreementCommandHandler(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public async Task<bool> Handle(PricingAgreementCommand request, CancellationToken cancellationToken)
        {
            await this._publisher.Publish(request, cancellationToken);
            return true;
        }
    }
}
