using DoCeluNaCzasMobile.DataAccess.Repository;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices;
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

        public PublicTransportHelper(HubService hubService, PublicTransportRepository publicTransportRepository)
        {
            _hubService = hubService;
            _publicTransportRepository = publicTransportRepository;
        }

        public async Task<BusStopData> GetBusStopDataAsync()
        {
            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    return await _hubService.GetBusStopData();
                }
                catch(InvalidOperationException ioe)
                {
                    break;
                }
                catch (Exception e) when (i < NumberOfRetries)
                {
                    await Task.Delay(DelayOnRetry);
                }
            }

            return await GetBusStops();
        }

        public async Task<List<JoinedTripsViewModel>> GetJoinedTripListAsync()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            return JsonConvert.DeserializeObject<List<JoinedTripsViewModel>>(json);
        }

        public async Task<BusStopData> GetBusStops()
        {
            var json = await _publicTransportRepository.GetBusStops();
            return JsonConvert.DeserializeObject<BusStopData>(json);
        }
    }
}
