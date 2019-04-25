using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount.Views;
using System;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAccountPage : ContentPage
    {
        public UserAccountPage()
        {
            InitializeComponent();

            var userLoggedIn = false;

            try
            {
                var user = CacheService.Get<User>(CacheKeys.USER);
                userLoggedIn = user != null && !string.IsNullOrEmpty(user.access_token);
            }
            catch (Exception e)
            {

            }

            if (userLoggedIn)
                Content = new UserLoggedInView();
            else
                Content = new LoginAndRegistrationView();
        }
    }
}