﻿using ProWebbCore.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProWebbCore.UI.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;

        public UserDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<User>>
                (await _httpClient.GetStreamAsync($"api/users"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<User> GetUserDetails(int userId)
        {
            return await JsonSerializer.DeserializeAsync<User>
                (await _httpClient.GetStreamAsync($"api/user/{userId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, MaxDepth = 2 });
        }

        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }


        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}