using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.Authorization;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services.Authorization
{
    public class AuthService
    {

        static readonly HttpClient Client = new HttpClient();
        readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();
        //TODO WYMAGANIA CO DO HASŁA

        public async Task<bool> EmailExist(string email)
        {
            var url = string.Format(Urls.EMAIL_EXIST, email);
            var json = await _publicTransportRepository.DownloadDataAsync(url);

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };

            var json = JsonConvert.SerializeObject(model);

            using (HttpContent content = new StringContent(json))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await Client.PostAsync(Urls.REGISTER, content);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Urls.TOKEN)
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            var response = await Client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            CacheService.Save(user, CacheKeys.USER);

            return true;
        }

        public async Task<bool> CheckCredentials(string email, string password, string confirmPassword)
        {

            if (await EmailExist(email))
            {
                await DisplayAlert("Email " + email + " już istnieje");
                return false;
            }

            if (!password.Equals(confirmPassword))
            {
                await DisplayAlert("Hasła muszą być takie same");
                return false;
            }

            if (password.Length < 6)
            {
                await DisplayAlert("Hasło musi mieć co najmniej 6 znaków długości");
                return false;
            }

            return true;
        }

        public async Task Register(string email, string password, string confirmPassword)
        {
            var canContinue = await CheckCredentials(email, password, confirmPassword);

            if (!canContinue) return;

            var isSuccess = await RegisterAsync(email, password, confirmPassword);

            if (isSuccess)
            {
                NavigationService.Navigate(typeof(UserAccountPage));
            }
            else
            {
                await DisplayAlert("Wystąpił błąd podczas rejestracji. Spróbuj ponownie później.");
            }
        }

        static async Task DisplayAlert(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Nieudana rejestracja", message, "OK");
        }
    }
}
