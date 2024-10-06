using CRM.Domain;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace CRM.Infastructure
{
    public class PIMService : IPIMService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PIMService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var baseURL = _configuration.GetSection("PIM.API.Endpoint").Value;
            //var response = await _httpClient.GetAsync(baseURL + "/products");
            //return await response.Content.ReadFromJsonAsync<List<Product>>();
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Description="Product description 1",
                    Name = "Product 1",
                    Price = 1000
                },
                new Product()
                {
                    Id = 2,
                    Description="Product description 2",
                    Name = "Product 2",
                    Price = 2000
                },
            };
        }
    }
}
