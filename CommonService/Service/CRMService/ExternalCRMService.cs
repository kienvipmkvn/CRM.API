using Microsoft.Extensions.Configuration;

namespace CRM.Infastructure
{
    public class ExternalCRMService : IExternalCRMService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExternalCRMService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> RegistPriceAgreement(PricingAgreementDTO pricingAgreement)
        {
            var baseURL = _configuration.GetSection("CRM.API.Endpoint").Value;
            //var response = await _httpClient.PostAsJsonAsync(baseURL + "/quote", pricingAgreement);
            //return response.IsSuccessStatusCode;
            return true;
        }
    }
}
