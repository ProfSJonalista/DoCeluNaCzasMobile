using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Views.DetailPages;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services
{
    public class NavigationService
    {
        internal /*async*/ static void NewMasterPage(string pageToNavigate, string busLineName)
        {
            var masterPage = new MainMasterPage();
            masterPage.Title = App.Current.MainPage.Title;

            switch (pageToNavigate)
            {
                case "RegisterPage":
                    masterPage.Detail = new NavigationPage(new RegisterPage());
                    break;

                case "UserAccountPage":
                    masterPage.Detail = new NavigationPage(new UserAccountPage());
                    break;

                case "BusStopChoicePage":
                    masterPage.Detail = new NavigationPage(new BusStopChoicePage(busLineName));
                    break;
            }

            App.Current.MainPage = masterPage;
        }
    }
}
