﻿using PairExpensesFS.Entities;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace PairXpensesFS.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PaymentReq>> GetPaymentsByUserAsync(int id)
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

		public async Task<bool> DeletePaymentAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"api/Payment/{id}");
			return response.IsSuccessStatusCode;
		}

		public async Task<PaymentReq> UpdatePayment(int Id, string NewName, long Value)
		{
			var updateModel = new PaymentReq { Id = Id, Name = NewName, Value = Value };

			var response = await _httpClient.PatchAsync($"api/Payment/{Id}", new StringContent(JsonSerializer.Serialize(updateModel), Encoding.UTF8, "application/json"));

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				Console.WriteLine("JSON Payload: " + responseBody);
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Handle case sensitivity
				var updatedUser = JsonSerializer.Deserialize<PaymentReq>(responseBody, options);

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

			return new PaymentReq() { Id = Id, Name = "FailedUpdate", Value = 0 };
		}

        public async Task<long?> GetTotalPaymentByUser(int userId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"api/Payment/total/{userId}");
                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    long totalPayment;
                    if (long.TryParse(content, out totalPayment))
                    {
                        return totalPayment;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    // Log the status code and content for debugging
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: Status Code: {response.StatusCode}, Content: {content}");

                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
