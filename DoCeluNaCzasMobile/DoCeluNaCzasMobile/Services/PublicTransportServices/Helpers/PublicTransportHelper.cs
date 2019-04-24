using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers
{
    public class PublicTransportHelper
    {
        private readonly HubService _hubService;
        private readonly PublicTransportRepository _publicTransportRepository;

        public PublicTransportHelper(HubService hubService)
        {
            _hubService = hubService;
            _publicTransportRepository = new PublicTransportRepository();
        }

        public async Task<BusStopDataModel> GetBusStopDataAsync()
        {
            if (_hubService.IsConnected())
            {
                return await _hubService.GetData<BusStopDataModel>(HubNames.GET_BUS_STOP_DATA);
            }

            var json = await _publicTransportRepository.GetBusStops();
            return JsonConvert.DeserializeObject<BusStopDataModel>(json);
        }

        public async Task<List<GroupedJoinedModel>> GetJoinedTripListAsync()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            return JsonConvert.DeserializeObject<List<GroupedJoinedModel>>(json);
        }
    }
}
