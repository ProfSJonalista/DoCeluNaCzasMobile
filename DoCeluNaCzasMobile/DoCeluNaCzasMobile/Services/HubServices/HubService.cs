using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.HubServices
{
    public class HubService
    {
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _hubProxy;

        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection()
        {
            await _hubConnection.Start();
        }

        public async Task<T> GetData<T>(string hubName)
        {
            return await _hubProxy.Invoke<T>(hubName);
        }

        public void Dispose()
        {
            if (_hubConnection.State == ConnectionState.Connected)
                _hubConnection.Dispose();
        }
    }
}
