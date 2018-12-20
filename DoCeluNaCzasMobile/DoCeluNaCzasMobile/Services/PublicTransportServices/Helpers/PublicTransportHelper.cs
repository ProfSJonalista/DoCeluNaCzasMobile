using DoCeluNaCzasMobile.DataAccess.Repository;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers
{
    public class PublicTransportHelper
    {
        const int NumberOfRetries = 3;
        const int DelayOnRetry = 1000;

        HubService _hubService;
        TimeTableService _timeTableService;
        PublicTransportRepository _publicTransportRepository;

        public PublicTransportHelper(HubService hubService, 
                                     TimeTableService timeTableService,
                                     PublicTransportRepository publicTransportRepository)
        {
            _hubService = hubService;
            _timeTableService = timeTableService;
            _publicTransportRepository = publicTransportRepository;
        }

        public async Task<BusLineData> GetBusLineDataAsync()
        {
            for (int i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    return await _hubService.GetBusLineData();
                }
                catch (InvalidOperationException ioe)
                {
                    break;
                }
                catch (Exception e) when (i < NumberOfRetries)
                {
                    await Task.Delay(DelayOnRetry);
                }
            }

            return await GetBusLines();
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
            List<JoinedTripsModel> joinedTripsModelList = await GetJoinedTrips();

            return _timeTableService.JoinedTripsMapper(joinedTripsModelList);
        }

        public async Task<List<JoinedTripsModel>> GetJoinedTrips()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            return JsonConvert.DeserializeObject<List<JoinedTripsModel>>(json);
        }

        public async Task<BusStopData> GetBusStops()
        {
            var json = await _publicTransportRepository.GetBusStops();
            return JsonConvert.DeserializeObject<BusStopData>(json);
        }

        public async Task<BusLineData> GetBusLines()
        {
            var json = await _publicTransportRepository.GetBusLines();
            return JsonConvert.DeserializeObject<BusLineData>(json);
        }
    }
}
