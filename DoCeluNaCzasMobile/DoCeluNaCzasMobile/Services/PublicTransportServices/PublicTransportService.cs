using DoCeluNaCzasMobile.DataAccess.Helpers;
using DoCeluNaCzasMobile.DataAccess.Repository;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using DoCeluNaCzasMobile.Services.PublicTransportServices.Helpers;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransportServices
{
    public class PublicTransportService
    {
        HubService _hubService;
        TimeTableService _timeTableService;
        PublicTransportHelper _publicTransportHelper;
        PublicTransportRepository _publicTransportRepository;

        public PublicTransportService()
        {
            _timeTableService = new TimeTableService();
            _publicTransportRepository = new PublicTransportRepository();
            _hubService = new HubService(Constants.HUB_CONNECTION, HubNames.PUBLIC_TRANSPORT_HUB);
            _publicTransportHelper = new PublicTransportHelper(_hubService, _timeTableService, _publicTransportRepository);
        }

        public async void GetDataWithSignalRAsync()
        {
            await _hubService.StartConnection();

            GetBusLineData();
            GetBusStopData();
            GetJoinedTripList();
        }

        private async void GetBusLineData()
        {
            var busLineData = await _publicTransportHelper.GetBusLineDataAsync();
            App.Current.Properties["BusLines"] = busLineData;
            SortBusLines(busLineData);
        }

        private async void GetBusStopData()
        {
            var busStopData = await _publicTransportHelper.GetBusStopDataAsync();
            App.Current.Properties["BusStops"] = busStopData;
        }

        private async void GetJoinedTripList()
        {
            var joinedTripsViewModelList = await _publicTransportHelper.GetJoinedTripListAsync();
            joinedTripsViewModelList = joinedTripsViewModelList.OrderBy(x => x.BusLineName).ToList();
            App.Current.Properties["JoinedTrips"] = joinedTripsViewModelList;
        }

        private void SortBusLines(BusLineData data)
        {
            List<Route> buses = data.Routes.Where(x => x.AgencyId == 1 
                                                    || x.AgencyId == 6
                                                    || x.AgencyId == 7
                                                    || x.AgencyId == 8
                                                    || x.AgencyId == 9
                                                    || x.AgencyId == 10
                                                    || x.AgencyId == 11
                                                    || x.AgencyId == 17
                                                    || x.AgencyId == 18).OrderBy(y => y.RouteShortName).ToList();

            List<Route> trams = data.Routes.Where(x => x.AgencyId == 2).OrderBy(y => y.RouteShortName).ToList();
            
            List<Route> trolleys = data.Routes.Where(x => x.AgencyId == 5).OrderBy(y => y.RouteShortName).ToList();

            App.Current.Properties["buses"] = buses;
            App.Current.Properties["trams"] = trams;
            App.Current.Properties["trolleys"] = trolleys;
        }
    }
}
