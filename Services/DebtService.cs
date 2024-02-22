using PairExpensesFS.Entities;
using System.Net.Http.Json;

namespace PairXpensesFS.Services
{
    public class DebtService
    {
        private readonly HttpClient _httpClient;

        public DebtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DebtReq>> GetDebtByUserAsync(int id)
        {
            var response = await _httpClient.GetAsync("api/Debt/user/" + id);

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<DebtReq>>();
                if(users != null)
                {
                    return users;
                }
                else
                {
                    return new List<DebtReq>() { };
                }

            }
            else
            {

                return new List<DebtReq>() { };

            }
        }

        public async Task CreateDebtAsync(Debt debt)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Debt", debt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
