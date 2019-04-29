using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Views.DetailPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services
{
    public class AuthService
    {
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

                    var response = await client.PostAsync(Urls.REGISTER, content);

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

            string content;

            using (var request = new HttpRequestMessage(HttpMethod.Post, Urls.TOKEN)
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

            CacheService.Save(user, CacheKeys.USER);

            NavigationService.Navigate(typeof(UserAccountPage));
        }

        private string RemoveChars(string content)
        {
            var charsToRemove = new[] { "." };

            return charsToRemove.Aggregate(content, (current, c) => current.Replace(c, string.Empty));
        }

        public async Task<string[]> GetData(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = await client.GetStringAsync(Urls.AUTHORIZED_VALUES);

                var data = JsonConvert.DeserializeObject<string[]>(json);

                return data;
            }
        }
    }
}
