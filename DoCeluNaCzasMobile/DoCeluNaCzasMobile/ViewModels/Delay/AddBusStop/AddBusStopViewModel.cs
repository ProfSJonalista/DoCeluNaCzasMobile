using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Delay;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop
{
    public class AddBusStopViewModel
    {
        public ObservableCollection<StopModel> Items { get; set; }
        readonly ChooseBusStopDelayService _chooseBusStopDelayService = new ChooseBusStopDelayService();

        public AddBusStopViewModel()
        {
            Items = CacheService.Get<BusStopDataModel>(CacheKeys.BUS_STOP_DATA_MODEL).Stops;
        }

        public void SaveToDb(StopModel item)
        {
            _chooseBusStopDelayService.SaveToDb(item);
            //TODO add toast
        }
    }
}
