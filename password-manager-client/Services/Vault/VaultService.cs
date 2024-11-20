using password_manager_client.Helpers;
using password_manager_client.Responses.Shared;
using password_manager_client.Services.Shared;
using password_manager_client.Services.Vault.Dto;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using password_manager_client.Helpers.Encryption;

using m = password_manager_client.Models;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        public async Task<Response<IList<Models.Vault>>> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"/api/v1/Vault/GetAllByUserId/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<IList<Models.Vault>>>(Program.JsonOptions);

                    if (result != null && result.Data != null)
                    {
                        return result;
                    }
                }

                return new Response<IList<Models.Vault>>
                {
                    Data = null,
                    Succeeded = false,
                    Message = "Failed to retrieve vaults.",
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public async Task<Response<Models.Vault>> GetVaultByIdAsync(Guid vaultId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"/api/v1/Vault/GetById/{vaultId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<Models.Vault>>(Program.JsonOptions);

                    if (result != null && result.Data != null)
                    {
                        return result;
                    }
                }

                return new Response<Models.Vault>
                {
                    Data = null,
                    Succeeded = false,
                    Message = "Failed to retrieve vault.",
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public async Task<Response<m.Vault>> UpdateVaultAsync(UpdateVaultDto vault)
        {
            try
            {
                vault.EncryptedPassword = EncryptionHelper.EncryptWithRSA(vault.EncryptedPassword, Session.PublicKey);

                string json = JsonSerializer.Serialize(vault, Program.JsonOptions);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"/api/v1/Vault/Update/{vault.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<m.Vault>>(Program.JsonOptions);

                    return result;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
