using password_manager_client.Responses.Auth;
using System.Net.Http.Headers;
using System.Reactive.Subjects;
using System.Text;
using System.Text.Json;
using System.Reactive.Linq;
using password_manager_client.Services.Auth.Dto;
using password_manager_client.Helpers.Decryption;

namespace password_manager_client.Services.Auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly BehaviorSubject<bool> _isAuthenticatedSubject = new(false);
        private string _authToken;

        public IObservable<bool> IsAuthenticatedObservable => _isAuthenticatedSubject.AsObservable();


        public AuthService(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
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
        public bool IsAuthenticated => !string.IsNullOrEmpty(_authToken);



        private async Task<bool> LoginAsync(LoginDto loginData)
        {
            string json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/Auth/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResponse>(responseContent);

                if (result != null)
                {
                    _authToken = result.Token;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
                    return true;
                }
            }

            return false;
        }


        private async Task<bool> RegisterAsync(RegisterDto registerData)
        {
            string json = JsonSerializer.Serialize(registerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/Auth/Register", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RegisterUserResponse>(responseContent);

                if (result != null)
                {
                    var encryptedPrivateKey = Convert.FromBase64String(result.EncryptedPrivateKey);
                    var encryptedAESKey = Convert.FromBase64String(result.EncryptedAESKey);
                    var salt = Convert.FromBase64String(result.Salt);

                    var derivedKey = DecryptionHelper.DeriveKeyFromPassword(registerData.MasterPassword, salt);

                    var aesKey = DecryptionHelper.DecryptWithAES(encryptedAESKey, derivedKey);

                    var privateKey = DecryptionHelper.DecryptWithAES(encryptedPrivateKey, aesKey);

                    // Store or use the private key as needed
                    // ...

                    return true;
                }
            }

            return false;
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
                HttpResponseMessage response = await _httpClient.GetAsync("/api/secure/data");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
        }
    }
}
