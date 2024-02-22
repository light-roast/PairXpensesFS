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

            if (response != null && response.IsSuccessStatusCode)
            {
                var payments = await response.Content.ReadFromJsonAsync<List<PaymentReq>>();
                if (payments != null)
                {
                    return payments;
                }
            }

            
            return new List<PaymentReq>();
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Payment", payment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
