using password_manager_client.Responses.Auth;
using System.Net.Http.Headers;
using System.Reactive.Subjects;
using System.Text;
using System.Text.Json;
using System.Reactive.Linq;
using password_manager_client.Services.Auth.Dto;
using password_manager_client.Helpers.Decryption;
using password_manager_client.Responses.Shared;
using password_manager_client.Services.Shared;
using System.Net.Http.Json;
using System.Net.Http;
using password_manager_client.Models;

namespace password_manager_client.Services.Auth
{
    public class AuthService : ApiService
    {
        private readonly BehaviorSubject<bool> _isAuthenticatedSubject = new(false);
        private string _authToken;

        public IObservable<bool> IsAuthenticatedObservable => _isAuthenticatedSubject.AsObservable();
        public bool IsAuthenticated => !string.IsNullOrEmpty(_authToken);

        public AuthService(HttpClient httpClient) : base(httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7260");
        }

        public IObservable<bool> Login(LoginDto loginData)
        {
            return Observable.FromAsync(() => LoginAsync(loginData))
                             .Retry(3)
                             .Do(isAuthenticated =>
                             {
                                 _isAuthenticatedSubject.OnNext(isAuthenticated);
                             });
        }

        public IObservable<bool> Register(RegisterDto registerData)
        {
            return Observable.FromAsync(() => RegisterAsync(registerData));
        }

        public async Task<bool> LoginAsync(LoginDto loginData)
        {
            string json = JsonSerializer.Serialize(loginData, Program.JsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/v1/Auth/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>(Program.JsonOptions);

                if (result != null)
                {
                    _authToken = result.Token;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);

                    Session.StartSession(result.UserId, _authToken, result.PrivateKey, result.Username);

                    return true;
                }
            }

            return false;
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
            _authToken = null;
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _isAuthenticatedSubject.OnNext(false);
        }

        public IObservable<string> GetSecureData()
        {
            if (string.IsNullOrEmpty(_authToken))
            {
                return Observable.Throw<string>(new InvalidOperationException("User is not authenticated."));
            }

            return Observable.FromAsync(async () =>
            {
                return await GetDataAsync<string>("/api/secure/data"); // Using GetDataAsync from ApiService
            });
        }
    }
}
