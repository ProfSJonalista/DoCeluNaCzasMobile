using System.Threading.Tasks;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Delay;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices
{
    public class PublicTransportService
    {
        private readonly HubService _hubService;
        private readonly DelayService _delayService;
        private readonly PublicTransportHelper _publicTransportHelper;

        public PublicTransportService()
        {
            _delayService = new DelayService();
            _hubService = new HubService(Urls.HUB_CONNECTION, HubNames.PUBLIC_TRANSPORT_HUB);
            _publicTransportHelper = new PublicTransportHelper(_hubService);
        }

        public async void GetDataWithSignalRAsync()
        {
            await _hubService.StartConnection();

            await GetBusStopData();
            await GetJoinedTripList();
            _delayService.SetChooseBusStopModelCollection();
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
