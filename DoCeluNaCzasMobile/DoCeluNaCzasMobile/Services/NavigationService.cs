using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Views.DetailPages;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services
{
    public static class NavigationService
    {
        internal static async void Navigate(Type targetType, params object[] parameters)
        {
            if (targetType != typeof(UserAccountPage))
            {
                if (!(Application.Current.MainPage is MasterDetailPage masterDetailPage))
                    return;

                var page = (Page)Activator.CreateInstance(targetType);

                if (targetType == typeof(AddBusStopPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new AddBusStopPage());
                }
                else if (targetType == typeof(BusStopChoicePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new BusStopChoicePage((string)parameters[0]));
                }
                else if (targetType == typeof(RegisterPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new RegisterPage());
                }
                else if (targetType == typeof(TimeTablePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new TimeTablePage((int)parameters[0]));
                }
                else if (targetType == typeof(DelaysPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new DelaysPage((int)parameters[0]));
                }
            }
            else
            {
                Application.Current.MainPage = new MainMasterPage()
                {
                    Detail = new NavigationPage(new UserAccountPage())
                };
            }
        }
    }
}
