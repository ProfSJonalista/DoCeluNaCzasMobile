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
        internal async void Navigate(Type targetType, string busLineName = null, int stopId = 0)
        {
            if (targetType != typeof(UserAccountPage))
            {
                var masterDetailPage = App.Current.MainPage as MasterDetailPage;
                var page = (Page)Activator.CreateInstance(targetType);

                if (targetType == typeof(AddBusStopPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new AddBusStopPage());
                }
                else if (targetType == typeof(BusStopChoicePage) && busLineName != null)
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new BusStopChoicePage(busLineName.ToString()));
                }
                else if (targetType == typeof(RegisterPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new RegisterPage());
                }
                else if (targetType == typeof(TimeTableTabbedPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new TimeTableTabbedPage());
                }
                else if(targetType == typeof(DelaysPage) && stopId != 0)
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new DelaysPage(stopId));
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
