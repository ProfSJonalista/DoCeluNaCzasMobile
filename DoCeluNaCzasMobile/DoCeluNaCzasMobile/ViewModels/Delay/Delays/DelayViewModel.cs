using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
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
            _hubService = new HubService(Urls.SERVER_CONNECTION, HubNames.DELAYS_HUB);
        }

        public async Task StartConnection() => await _hubService.StartConnection();

        public void StopConnection() => _hubService.StopConnection();

        public async Task<ObservableCollection<DelayModel>> SetItems()
        {
            if (_hubService.IsConnected())
            {
                return await _hubService.GetData<ObservableCollection<DelayModel>>(HubNames.GET_DELAYS, _stopId);
            }

            return new ObservableCollection<DelayModel>();
        }
    }
}
