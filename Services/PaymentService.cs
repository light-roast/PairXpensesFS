using PairExpensesFS.Entities;
using System.Net.Http.Json;

namespace PairXpensesFS.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PaymentReq>> GetPaymentByUserAsync(int id)
        {
            var response = await _httpClient.GetAsync("api/Payment/user/" + id);

            if (response.IsSuccessStatusCode)
            {
                var payments = await response.Content.ReadFromJsonAsync<List<PaymentReq>>();
                return payments;
            }
            else
            {

                return new List<PaymentReq>() { };
            }
        }
    }
}
