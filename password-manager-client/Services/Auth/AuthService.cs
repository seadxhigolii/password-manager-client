using password_manager_client.Responses.Auth;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using password_manager_client.Services.Auth.Dto;
using password_manager_client.Helpers.Decryption;
using password_manager_client.Responses.Shared;
using password_manager_client.Services.Shared;
using System.Net.Http.Json;
using password_manager_client.Helpers;

namespace password_manager_client.Services.Auth
{
    public class AuthService : ApiService
    {
        public AuthService(HttpClient httpClient) : base(httpClient) 
        {
        }

        public async Task<Response<bool>> LoginAsync(LoginDto loginData)
        {
            try
            {
                string json = JsonSerializer.Serialize(loginData, Program.JsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("/api/v1/Auth/Login", content);

                var loginResponse = new Response<bool>();

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<LoginResponse>>(Program.JsonOptions);

                    if (result != null && result.Data != null)
                    {
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Data.AuthToken);

                        Session.StartSession(result.Data.UserId, result.Data.AuthToken, result.Data.PrivateKey, result.Data.PublicKey, result.Data.Username);

                        Properties.Settings.Default.SavedEmail = loginData.Username;
                        Properties.Settings.Default.Save();

                        if (Session.IsAuthenticated)
                        {

                            loginResponse = new Response<bool>{
                                Data = true,
                                StatusCode = 200
                            };
                            return loginResponse;
                        }
                        else
                        {
                            loginResponse = new Response<bool>
                            {
                                Data = false,
                                StatusCode = 200
                            };
                            return loginResponse;
                        }
                    }
                }

                loginResponse = new Response<bool>
                {
                    Data = false,
                    StatusCode = (int)response.StatusCode,
                    Message = await response.Content.ReadAsStringAsync()
                };

                return loginResponse;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }            
        }

        public async Task<bool> RegisterAsync(RegisterDto registerData)
        {
            try
            {
                string json = JsonSerializer.Serialize(registerData, Program.JsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("/api/v1/Auth/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Response<RegisterUserResponse>>(Program.JsonOptions);

                    if (result?.Data != null)
                    {
                        var encryptedPrivateKey = Convert.FromBase64String(result.Data.EncryptedPrivateKey);
                        var encryptedAESKey = Convert.FromBase64String(result.Data.EncryptedAESKey);
                        var salt = Convert.FromBase64String(result.Data.Salt);

                        var derivedKey = DecryptionHelper.DeriveKeyFromPassword(registerData.MasterPassword, salt);
                        var aesKey = DecryptionHelper.DecryptWithAES(encryptedAESKey, derivedKey);
                        var privateKey = DecryptionHelper.DecryptWithAES(encryptedPrivateKey, aesKey);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception("Registration failed", e);
            }
        }

        public void Logout()
        {
            Session.EndSession();
        }
    }
}
