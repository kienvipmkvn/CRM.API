namespace CRM.API.MassTransit
{
    public class LeadConvertedCommand
    {
        public int LeadId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ConvertedDate { get; set; } = DateTime.Now;
    }
}
