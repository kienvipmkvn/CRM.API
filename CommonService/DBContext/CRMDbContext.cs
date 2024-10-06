using CRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infastructure
{
    public class CRMDbContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }

        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {
        }
    }
}
