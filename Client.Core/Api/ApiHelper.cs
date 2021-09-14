using Client.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Api
{
    public class ApiHelper : IApiHelper
    {
        private readonly IConfiguration _config;
        private HttpClient _apiClient;


        public HttpClient ApiClient => _apiClient;


        public ApiHelper(IConfiguration config)
        {
            _config = config;
            InitializeClient();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
        }

        private void InitializeClient()
        {
            string api = _config.GetValue<string>("api");

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUserModel> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "email", username },
                { "password", password }
            });

            HttpResponseMessage response = await _apiClient.PostAsync("/api/Account/Login", data);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<AuthenticatedUserModel>();

                // Add token to Headers
                _apiClient.DefaultRequestHeaders.Clear();
                _apiClient.DefaultRequestHeaders.Accept.Clear();
                _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);

                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
