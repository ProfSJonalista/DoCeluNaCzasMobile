using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Delay;
using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose.Commands;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose
{
    public class DelayBusStopChooseViewModel
    {
        public ObservableCollection<ChooseBusStopViewModel> Items { get; set; }
        public NavigateToAddPageCommand NavToAddPageCommand { get; set; }
        ChooseBusStopDelayService ChooseBusStopDelayService { get; }


        public DelayBusStopChooseViewModel()
        {
            NavToAddPageCommand = new NavigateToAddPageCommand(this);
            ChooseBusStopDelayService = new ChooseBusStopDelayService();
        }

        public ObservableCollection<ChooseBusStopViewModel> GetUserBusStops()
        {
            var stops = ChooseBusStopDelayService.GetUserBusStops();

            var modifiedStops = stops.Select(stop => new ChooseBusStopViewModel
            {
                ChooseBusStopModel = stop,
                DelayBusStopChooseViewModel = this
            }).ToList();

            Items = new ObservableCollection<ChooseBusStopViewModel>(modifiedStops);

            return Items;
        }

        public void NavigateToAddPage()
        {
            ChooseBusStopDelayService.Navigate(typeof(AddBusStopPage));
        }

        public void Navigate(Type type, int stopId)
        {
            ChooseBusStopDelayService.Navigate(type, stopId);
        }

        public void DeleteStop(ChooseBusStopModel stopToDelete)
        {
            ChooseBusStopDelayService.DeleteFromDb(stopToDelete);
            var toDelete = Items.FirstOrDefault(x => x.ChooseBusStopModel.StopId == stopToDelete.StopId);
            Items.Remove(toDelete);
        }
    }
}
