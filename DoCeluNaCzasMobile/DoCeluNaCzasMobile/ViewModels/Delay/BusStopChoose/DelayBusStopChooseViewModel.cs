using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Delay;
using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose.Commands;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose
{
    public class DelayBusStopChooseViewModel
    {
        public static ObservableCollection<ChooseBusStopModel> ChooseBusStopModelObservableCollection { get; set; }
        public NavigateToAddPageCommand NavToAddPageCommand { get; set; }

        public static DelayService DelayService = new DelayService();

        public DelayBusStopChooseViewModel()
        {
            NavToAddPageCommand = new NavigateToAddPageCommand(this);
        }

        public static ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            ChooseBusStopModelObservableCollection = DelayService.GetUserBusStops();
            return ChooseBusStopModelObservableCollection;
        }

        public void NavigateToAddPage()
        {
            DelayService.Navigate(typeof(AddBusStopPage));
        }
    }
}
