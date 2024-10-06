namespace CRM.Application
{
    public class LeadConvertedDTO
    {
        public int LeadId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ConvertedDate { get; set; } = DateTime.Now;
    }
}
