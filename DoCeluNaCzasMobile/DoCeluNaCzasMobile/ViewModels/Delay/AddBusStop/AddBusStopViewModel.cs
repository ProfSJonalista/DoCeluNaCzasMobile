using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;

namespace DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop
{
    public class AddBusStopViewModel
    {
        public ObservableCollection<ChooseBusStopModel> Items { get; set; }

        public AddBusStopViewModel()
        {
            Items = CacheService.Get<ObservableCollection<ChooseBusStopModel>>(CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
        }
    }
}
