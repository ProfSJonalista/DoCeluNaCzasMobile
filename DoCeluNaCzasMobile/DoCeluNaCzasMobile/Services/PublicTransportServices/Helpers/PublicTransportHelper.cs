using DoCeluNaCzasMobile.DataAccess.Repository;
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
        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 1000;

        private readonly HubService _hubService;
        private readonly PublicTransportRepository _publicTransportRepository;

        public PublicTransportHelper(HubService hubService)
        {
            _hubService = hubService;
            _publicTransportRepository = new PublicTransportRepository();
        }

        public async Task<BusStopDataModel> GetBusStopDataAsync()
        {
            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    return await _hubService.GetBusStopData<BusStopDataModel>(HubNames.GET_BUS_STOP_DATA);
                }
                catch(InvalidOperationException ioe)
                {
                    await Task.Delay(DelayOnRetry);
                }
                catch (Exception e) when (i < NumberOfRetries)
                {
                    await Task.Delay(DelayOnRetry);
                }
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
