using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers;
using System.Threading.Tasks;

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

            await GetBusStopData();
            await GetJoinedTripList();
            await GetChooseBusStopModelCollection();

            _hubService.StopConnection();
        }

        private async Task GetChooseBusStopModelCollection()
        {
            var chooseBusStopModelCollection = await _publicTransportHelper.GetChooseBusStopCollectionAsync();
            CacheService.Save(chooseBusStopModelCollection, CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
        }

        private async Task GetBusStopData()
        {
            var busStopData = await _publicTransportHelper.GetBusStopDataAsync();
            CacheService.Save(busStopData, CacheKeys.BUS_STOP_DATA_MODEL);
        }

        private async Task GetJoinedTripList()
        {
            var joinedTripsViewModelList = await _publicTransportHelper.GetJoinedTripListAsync();
            CacheService.Save(joinedTripsViewModelList, CacheKeys.GROUPED_JOINED_MODEL_LIST);
        }
    }
}
