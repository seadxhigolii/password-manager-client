using password_manager_client.Helpers;
using password_manager_client.Responses.Auth;
using password_manager_client.Responses.Shared;
using password_manager_client.Services.Auth.Dto;
using password_manager_client.Services.Shared;
using password_manager_client.Services.Vault.Dto;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using password_manager_client.Helpers.Encryption;

namespace password_manager_client.Services.Vault
{
    public class VaultService : ApiService
    {
        public VaultService(HttpClient httpClient) : base(httpClient) { }

        public async Task<bool> CreateAsync(CreateVaultDto vault)
        {
            try
            {
                vault.EncryptedPassword = EncryptionHelper.EncryptWithRSA(vault.EncryptedPassword, Session.PublicKey);

                string json = JsonSerializer.Serialize(vault, Program.JsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("/api/v1/Vault/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<bool>>(Program.JsonOptions);

                    if (result != null && result.Data != null)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
