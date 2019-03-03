using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.HubServices
{
    public class HubService
    {
        HubConnection _hubConnection;
        IHubProxy _hubProxy;
        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection()
        {
            await _hubConnection.Start();
        }

        public async Task<BusStopData> GetBusStopData()
        {
            return await _hubProxy.Invoke<BusStopData>(HubNames.GET_BUS_STOP_DATA);
        }

        public async Task<List<JoinedTripsViewModel>> GetJoinedTrips()
        {
            return await _hubProxy.Invoke<List<JoinedTripsViewModel>>(HubNames.GET_JOINED_TRIPS_MODEL_DATA);
        }
    }
}
