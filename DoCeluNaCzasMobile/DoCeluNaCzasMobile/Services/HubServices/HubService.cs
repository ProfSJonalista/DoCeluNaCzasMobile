using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
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
        
        public async Task<BusLineData> GetBusLineData()
        {
            return await _hubProxy.Invoke<BusLineData>(HubNames.GET_BUS_LINE_DATA);
        }

        public async Task<BusStopData> GetBusStopData()
        {
            return await _hubProxy.Invoke<BusStopData>(HubNames.GET_BUS_STOP_DATA);
        }

        public async Task<List<JoinedTripsModel>> GetJoinedTrips()
        {
            return await _hubProxy.Invoke<List<JoinedTripsModel>>(HubNames.GET_JOINED_TRIPS_MODEL_DATA);
        }
    }
}
