using PairExpensesFS.Entities;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;


namespace PairXpensesFS.Services
{
    public class DebtService
    {
        private readonly HttpClient _httpClient;

        public DebtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DebtReq>> GetDebtsByUserAsync(int id)
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

        public async Task<bool> DeleteDebtAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Debt/{id}");
            return response.IsSuccessStatusCode;
        }

		public async Task<DebtReq> UpdateDebt(int Id, string NewName, long Value)
		{
			var updateModel = new DebtReq { Id = Id, Name = NewName, Value = Value };

			var response = await _httpClient.PatchAsync($"api/Debt/{Id}", new StringContent(JsonSerializer.Serialize(updateModel), Encoding.UTF8, "application/json"));

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Handle case sensitivity
				var updatedUser = JsonSerializer.Deserialize<DebtReq>(responseBody, options);

				if (updatedUser != null)
				{
					return updatedUser;
				}
				else
				{
					Console.WriteLine("Deserialization of user failed.");
				}
			}
			else
			{
				Console.WriteLine("Failed to update user. Status code: " + response.StatusCode);
			}

			return new DebtReq() { Id = Id, Name = "FailedUpdate", Value = 0 };
		}

		public async Task<long?> GetTotalDebtByUser(int userId)
		{
			try
			{
				// Make the API call
				HttpResponseMessage response = await _httpClient.GetAsync($"api/Debt/total/{userId}");

				// Check if the call was successful
				response.EnsureSuccessStatusCode();

				// Read the response content
				if (response.IsSuccessStatusCode)
				{
                    string content = await response.Content.ReadAsStringAsync();
                    long totalDebt;
                    if (long.TryParse(content, out totalDebt))
                    {
                        return totalDebt;
                    }
                    else
                    {
                        return null;
                    }
                }
				else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
					// Handle bad request
					return null;
				}
				else
				{
					// Handle other error cases
					return null;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions
				// Log the error, show a message to the user, etc.
				// You can throw the exception or return a default value
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}
	}
}
