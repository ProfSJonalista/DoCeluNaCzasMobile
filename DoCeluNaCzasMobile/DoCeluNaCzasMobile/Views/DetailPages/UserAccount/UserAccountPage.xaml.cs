﻿using DoCeluNaCzasMobile.Models.Authorization;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.UserAccount
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
                userLoggedIn = user != null && !string.IsNullOrEmpty(user.AccessToken);
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