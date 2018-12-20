using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Views.DetailPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.UserLoggedIn
{
    public class LoggedInViewModel
    {
        NavigationService _navigationService = new NavigationService();
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.Properties["user"] = new User();

                    _navigationService.Navigate(typeof(UserAccountPage), "");
                });
            }
        }
    }
}
