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

namespace DoCeluNaCzasMobile.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //TODO - klasa z linkami
            var response = await client.PostAsync("http://docelunaczaswebapi.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            //TODO - klasa z linkami
            var request = new HttpRequestMessage(HttpMethod.Post, "http://docelunaczaswebapi.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            content = removeChars(content);

            var user = JsonConvert.DeserializeObject<User>(content);

            App.Current.Properties["user"] = user;

            NavigationService.Navigate(typeof(UserAccountPage), "");
        }

        private string removeChars(string content)
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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //TODO - klasa z linkami
            var json = await client.GetStringAsync("http://docelunaczaswebapi.azurewebsites.net/api/AuthorizedValues");

            var data = JsonConvert.DeserializeObject<string[]>(json);

            return data;
        }
    }
}
