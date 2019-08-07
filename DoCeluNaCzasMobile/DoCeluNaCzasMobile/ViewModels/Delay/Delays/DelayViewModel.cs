using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.ViewModels.Delay.Delays
{
    public class DelayViewModel
    {
        readonly int _stopId;
        readonly HubService _hubService;

        public DelayViewModel(int stopId)
        {
            _stopId = stopId;
            _hubService = new HubService(HubNames.DELAYS_HUB);
        }

        public async Task StartConnection() => await _hubService.StartConnection();

        public void StopConnection() => _hubService.StopConnection();

        public async Task<ObservableCollection<DelayModel>> SetItems() => 
            await _hubService.GetData<ObservableCollection<DelayModel>, int>(HubNames.GET_DELAYS_METHOD, _stopId);
    }
}
