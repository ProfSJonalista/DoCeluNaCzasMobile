using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Views.DetailPages;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services
{
    public class NavigationService
    {
        internal async void Navigate(Type targetType, string busLineName = "")
        {
            if (targetType != typeof(UserAccountPage))
            {
                var masterDetailPage = App.Current.MainPage as MasterDetailPage;
                var page = (Page)Activator.CreateInstance(targetType);


                if (targetType == typeof(AddBusStopPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new AddBusStopPage());
                }
                else if (targetType == typeof(BusStopChoicePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new BusStopChoicePage(busLineName));
                }
                else if (targetType == typeof(RegisterPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new RegisterPage());
                }
                else if (targetType == typeof(TimeTableTabbedPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new TimeTableTabbedPage());
                }
            }
            else
            {
                App.Current.MainPage = new MainMasterPage()
                {
                    Detail = new NavigationPage(new UserAccountPage())
                };
            }
        }
    }
}
