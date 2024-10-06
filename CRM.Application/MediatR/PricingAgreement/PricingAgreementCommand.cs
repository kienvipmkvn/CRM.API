using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application
{
    public class PricingAgreementCommand : IRequest<bool>
    {
        public string CustomerCode { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
