using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using DoCeluNaCzasMobile.Views.DetailPages.RouteSearch;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using DoCeluNaCzasMobile.Views.MainPage;
using System;
using System.Collections.Generic;
using DoCeluNaCzasMobile.Services.RouteSearch;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services.Navigation
{
    public static class NavigationService
    {
        internal static async void Navigate(Type targetType, params object[] parameters)
        {
            if (targetType != typeof(UserAccountPage))
            {
                if (!(Application.Current.MainPage is MasterDetailPage masterDetailPage))
                    return;

                if (targetType == typeof(RegisterPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new RegisterPage());
                }
                else if (targetType == typeof(AddBusStopPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new AddBusStopPage());
                }
                else if (targetType == typeof(DelaysPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new DelaysPage((StopModel)parameters[0]));
                }
                else if (targetType == typeof(ChooseStopPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new ChooseStopPage((bool)parameters[0]));
                }
                else if (targetType == typeof(RoutesPage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new RoutesPage((List<Route>)parameters[0]));
                }
                else if (targetType == typeof(ChangePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new ChangePage((List<Change>)parameters[0], (RouteSearchDelayService)parameters[1]));
                }
                else if (targetType == typeof(BusStopChoicePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new BusStopChoicePage((string)parameters[0]));
                }
                else if (targetType == typeof(TimeTablePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new TimeTablePage((MinuteTimeTable)parameters[0]));
                }
                else if (targetType == typeof(StopChangePage))
                {
                    await masterDetailPage.Detail.Navigation.PushAsync(new StopChangePage((List<StopChange>)parameters[0], (RouteSearchDelayService) parameters[1]));
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

        internal static async void ClosePage()
        {
            if (!(Application.Current.MainPage is MasterDetailPage masterDetailPage))
                return;

            await masterDetailPage.Detail.Navigation.PopAsync();
        }
    }
}
