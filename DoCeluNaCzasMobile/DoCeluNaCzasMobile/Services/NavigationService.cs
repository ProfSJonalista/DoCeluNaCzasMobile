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
            App.Current.MainPage = new MainMasterPage
            {
                Title = App.Current.MainPage.Title,
                Detail = GetDetailPage(pageToNavigate, busLineName)
            };
        }

        private static Page GetDetailPage(string pageToNavigate, string busLineName)
        {
            switch (pageToNavigate)
            {
                case "RegisterPage":
                    return new NavigationPage(new RegisterPage());

                case "UserAccountPage":
                    return new NavigationPage(new UserAccountPage());

                case "BusStopChoicePage":
                    return new NavigationPage(new BusStopChoicePage(busLineName));

                default:
                    return new NavigationPage(new Page());
            }
        }
    }
}
