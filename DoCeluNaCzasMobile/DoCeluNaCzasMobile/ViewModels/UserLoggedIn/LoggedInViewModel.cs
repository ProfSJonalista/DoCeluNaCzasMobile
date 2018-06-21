using DoCeluNaCzasMobile.Models;
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
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.Properties["user"] = new User();

                    var masterPage = new MainMasterPage();
                    masterPage.Title = App.Current.MainPage.Title;
                    masterPage.Detail = new NavigationPage(new UserAccountPage());

                    App.Current.MainPage = masterPage;
                });
            }
        }
    }
}
