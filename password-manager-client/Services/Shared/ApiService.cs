using System.Net.Http;
using System.Text.Json;

namespace password_manager_client.Services.Shared
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:7260");
        }
    }
}
