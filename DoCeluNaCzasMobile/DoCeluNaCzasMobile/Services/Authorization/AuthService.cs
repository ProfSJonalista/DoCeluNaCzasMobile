using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.Authorization;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.Authorization
{
    public class AuthService
    {
        static readonly HttpClient Client = new HttpClient();

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
            content = RemoveChars(content);
            var user = JsonConvert.DeserializeObject<User>(content);

            CacheService.Save(user, CacheKeys.USER);


            return true;
        }

        string RemoveChars(string content)
        {
            var charsToRemove = new[] { "." };

            return charsToRemove.Aggregate(content, (current, c) => current.Replace(c, string.Empty));
        }
    }
}

//using (var request = new HttpRequestMessage(HttpMethod.Post, Urls.TOKEN)
//{
//Content = new FormUrlEncodedContent(keyValues)
//})

//using (var client = new HttpClient())
//{
//var response = await client.SendAsync(request);

//content = await response.Content.ReadAsStringAsync();
//}

//content = RemoveChars(content);

//var user = JsonConvert.DeserializeObject<User>(content);

//CacheService.Save(user, CacheKeys.USER);

//NavigationService.Navigate(typeof(UserAccountPage));
//}

//string RemoveChars(string content)
//{
//var charsToRemove = new[] { "." };

//return charsToRemove.Aggregate(content, (current, c) => current.Replace(c, string.Empty));
//}

//public async Task<string[]> GetData(string accessToken)
//{
//Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

//var json = await Client.GetStringAsync(Urls.AUTHORIZED_VALUES);
//var data = JsonConvert.DeserializeObject<string[]>(json);

//return data;
//}