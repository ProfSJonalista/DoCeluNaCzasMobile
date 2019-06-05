using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Delay;
using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose.Commands;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose
{
    public class DelayBusStopChooseViewModel
    {
        public ObservableCollection<ChooseBusStopModel> Items { get; set; }
        public NavigateToAddPageCommand NavToAddPageCommand { get; set; }

        public static ChooseBusStopDelayService ChooseBusStopDelayService = new ChooseBusStopDelayService();

        public DelayBusStopChooseViewModel()
        {
            NavToAddPageCommand = new NavigateToAddPageCommand(this);
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            Items = ChooseBusStopDelayService.GetUserBusStops();
            return Items;
        }

        public void NavigateToAddPage()
        {
            ChooseBusStopDelayService.Navigate(typeof(AddBusStopPage));
        }
    }
}
