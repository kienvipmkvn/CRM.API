using MediatR;

namespace CRM.Application
{
    public class LeadConvertedCommand : IRequest<bool>
    {
        public int LeadId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ConvertedDate { get; set; } = DateTime.Now;
    }
}
