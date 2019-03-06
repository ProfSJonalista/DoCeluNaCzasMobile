using DoCeluNaCzasMobile.DataAccess.Repository.Helpers;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices
{
    public class PublicTransportService
    {
        private readonly HubService _hubService;
        private readonly PublicTransportHelper _publicTransportHelper;

        public PublicTransportService()
        {
            _hubService = new HubService(Urls.HUB_CONNECTION, HubNames.PUBLIC_TRANSPORT_HUB);
            _publicTransportHelper = new PublicTransportHelper(_hubService);
        }

        public async void GetDataWithSignalRAsync()
        {
            await _hubService.StartConnection();

            GetBusStopData();
            GetJoinedTripList();
        }

        private async void GetBusStopData()
        {
            var busStopData = await _publicTransportHelper.GetBusStopDataAsync();
            //todo save to sqldb
            App.Current.Properties["BusStops"] = busStopData;
        }

        private async void GetJoinedTripList()
        {
            var joinedTripsViewModelList = await _publicTransportHelper.GetJoinedTripListAsync();
            //todo save to sqldb
            App.Current.Properties["JoinedTrips"] = joinedTripsViewModelList;
        }
    }
}
