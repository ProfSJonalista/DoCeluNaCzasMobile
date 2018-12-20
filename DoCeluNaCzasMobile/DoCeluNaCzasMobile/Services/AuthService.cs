using DoCeluNaCzasMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DoCeluNaCzasMobile.Views.DetailPages;
using DoCeluNaCzasMobile.Views;
using Xamarin.Forms;
using DoCeluNaCzasMobile.DataAccess.Helpers;

namespace DoCeluNaCzasMobile.Services
{
    public class AuthService
    {
        readonly NavigationService _navigationService;

        public AuthService()
        {
            _navigationService = new NavigationService();
        }

        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            using (var client = new HttpClient())
            {
                var model = new RegisterBindingModel()
                {
                    Email = email,
                    Password = password,
                    ConfirmPassword = password
                };

                var json = JsonConvert.SerializeObject(model);

                using (var content = new StringContent(json))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PostAsync(Constants.REGISTER, content);

                    return response.IsSuccessStatusCode;
                }
            }
        }

        public async Task LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var content = string.Empty;

            using(var request = new HttpRequestMessage(HttpMethod.Post, Constants.TOKEN)
            {
                Content = new FormUrlEncodedContent(keyValues)
            })
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                content = await response.Content.ReadAsStringAsync();
            }

            content = RemoveChars(content);

            var user = JsonConvert.DeserializeObject<User>(content);

            App.Current.Properties["user"] = user;

            _navigationService.Navigate(typeof(UserAccountPage), "");
        }

        private string RemoveChars(string content)
        {
            var charsToRemove = new string[] { "." };

            foreach (var c in charsToRemove)
            {
                content = content.Replace(c, string.Empty);
            }

            return content;
        }

        public async Task<string[]> GetData(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = await client.GetStringAsync(Constants.AUTHORIZED_VALUES);

                var data = JsonConvert.DeserializeObject<string[]>(json);

                return data;
            }
        }
    }
}
