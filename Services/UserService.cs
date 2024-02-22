﻿using PairExpensesFS.Entities;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;



namespace PairXpensesFS.Services
{
    public class UserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserReq>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("api/User");

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<UserReq>>();
                if(users != null)
                {
                    return users;
                }
                else
                {
                    return new List<UserReq>() {

                    new UserReq { Id = 1, Name = "UserA" },
                    new UserReq { Id = 2, Name = "UserB" },

                    };
                }
            }
            else
            {
                
                return new List<UserReq>() {
            
                new UserReq { Id = 1, Name = "UserA" },
                new UserReq { Id = 2, Name = "UserB" },
           
                }; 
            }
        }

        public async Task<UserReq> UpdateUser(int UserId, string NewName)
        {
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

    }
}


