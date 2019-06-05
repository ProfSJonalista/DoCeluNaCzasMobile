using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers
{
    public class PublicTransportHelper
    {
        readonly HubService _hubService;
        readonly PublicTransportRepository _publicTransportRepository;

        public PublicTransportHelper(HubService hubService)
        {
            _hubService = hubService;
            _publicTransportRepository = new PublicTransportRepository();
        }

        public async Task<BusStopDataModel> GetBusStopDataAsync()
        {
            var busStopDataModel = new BusStopDataModel();

            if (_hubService.IsConnected())
            {
                busStopDataModel = await _hubService.GetData<BusStopDataModel>(HubNames.GET_BUS_STOP_DATA);
            }

            if (busStopDataModel?.Stops != null) return busStopDataModel;

            var json = await _publicTransportRepository.GetBusStops();
            busStopDataModel = Deserialize<BusStopDataModel>(json);

            return busStopDataModel;
        }

        public async Task<List<GroupedJoinedModel>> GetJoinedTripListAsync()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            var data = Deserialize<List<GroupedJoinedModel>>(json);

            return data;
        }

        public async Task<ObservableCollection<ChooseBusStopModel>> GetChooseBusStopCollectionAsync()
        {
            var json = await _publicTransportRepository.GetChooseBusStopObservableCollection();
            var data = Deserialize<ObservableCollection<ChooseBusStopModel>>(json);

            return data;
        }

        static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
