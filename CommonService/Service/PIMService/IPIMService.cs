using CRM.Domain;

namespace CRM.Infastructure
{
    public interface IPIMService
    {
        Task<List<Product>> GetProductsAsync();
    }
}