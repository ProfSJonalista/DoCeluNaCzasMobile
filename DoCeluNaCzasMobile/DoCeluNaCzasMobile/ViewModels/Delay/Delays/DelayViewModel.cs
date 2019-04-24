using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;

namespace DoCeluNaCzasMobile.ViewModels.Delay.Delays
{
    public class DelayViewModel
    {
        private bool _isConnected;
        private static Timer _timer;
        private readonly int _stopId;
        private readonly HubService _hubService;
        public ObservableCollection<DelayModel> Items { get; set; }

        public DelayViewModel(int stopId)
        {
            _stopId = stopId;
            Items = new ObservableCollection<DelayModel>();
            _hubService = new HubService(Urls.HUB_CONNECTION, HubNames.DELAYS_HUB);
        }

        public void SetTimer()
        {
            const int timeInMilliseconds = 20000; //20 seconds
            _timer = new Timer(timeInMilliseconds);
            _timer.Elapsed += UpdateDataEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void UpdateDataEvent(object sender, ElapsedEventArgs e)
        {
            SetItems();
        }

        public async void SetItems()
        {
            if (_isConnected)
            {
                Items = await _hubService.GetData<ObservableCollection<DelayModel>>(HubNames.GET_DELAYS, _stopId);
            }
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        public async Task StartConnection()
        {
            await _hubService.StartConnection();
            _isConnected = _hubService.IsConnected();
        }

        public void StopConnection()
        {
            _hubService.StopConnection();
            _isConnected = _hubService.IsConnected();
        }
    }
}
