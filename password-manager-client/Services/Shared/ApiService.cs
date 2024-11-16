using password_manager_client.Helpers;
using System.Net.Http.Headers;

namespace password_manager_client.Services.Shared
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:7260");

            var authToken = Session.AuthToken;
            if (!string.IsNullOrEmpty(authToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
        }
    }
}
