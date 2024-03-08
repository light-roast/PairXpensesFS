using PairExpensesFS.Entities;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.JSInterop;
using System.Net.Http.Headers;



namespace PairXpensesFS.Services
{
    public class UserService
    {

        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;

        public UserService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<List<UserReq>> GetUsersAsync()
        {
            // Get token from local storage
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

            // Check if token is present
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Token not found in local storage.");
            }

            // Add token to authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/User");

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<UserReq>>();
                if (users != null)
                {
                    return users;
                }
                else
                {
                    return new List<UserReq>()
                    {
                        new UserReq { Id = 1, Name = "UserA" },
                        new UserReq { Id = 2, Name = "UserB" }
                    };
                }
            }
            else
            {
                // Handle unsuccessful response
                return new List<UserReq>()
                {
                new UserReq { Id = 1, Name = "UserA" },
                new UserReq { Id = 2, Name = "UserB" }
                };
            }
        }

        public async Task<UserReq> UpdateUser(int UserId, string NewName)
        {
            // Get token from local storage
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");

            // Check if token is present
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Token not found in local storage.");
            }

            // Add token to authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var updateModel = new UserReq { Id = UserId, Name = NewName };

            var response = await _httpClient.PatchAsync($"api/user/{UserId}", new StringContent(JsonSerializer.Serialize(updateModel), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Handle case sensitivity
                var updatedUser = JsonSerializer.Deserialize<UserReq>(responseBody, options);

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

            return new UserReq() { Id = UserId, Name = "FailedUpdate" };
        }

        public async Task<bool> Login(string username, string password)
        {
            var requestData = new
            {
                Username = username,
                Password = password
            };

            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Account/Login", content);
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


