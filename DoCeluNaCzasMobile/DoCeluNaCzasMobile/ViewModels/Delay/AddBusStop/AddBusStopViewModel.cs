using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Delay;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop
{
    public class AddBusStopViewModel
    {
        public ObservableCollection<ChooseBusStopModel> Items { get; set; }
        readonly ChooseBusStopDelayService _chooseBusStopDelayService = new ChooseBusStopDelayService();

        public AddBusStopViewModel()
        {
            Items = CacheService.Get<ObservableCollection<ChooseBusStopModel>>(CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
        }

        public void SaveToDb(ChooseBusStopModel item)
        {
            _chooseBusStopDelayService.SaveToDb(item);
            //TODO add toast
        }
    }
}
