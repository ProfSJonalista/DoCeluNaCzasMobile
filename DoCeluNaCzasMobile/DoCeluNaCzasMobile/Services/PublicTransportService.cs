using DoCeluNaCzasMobile.DataAccess;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DoCeluNaCzasMobile.Services
{
    public class PublicTransportService
    {
        PublicTransportRepository _publicTransportRepository;
        TimeTableService _timeTableService;

        public PublicTransportService()
        {
            _publicTransportRepository = new PublicTransportRepository();
            _timeTableService = new TimeTableService();
        }

        public void GetData()
        {
            GetJoinedTrips();
            GetBusStops();
            GetBusLines();
        }

        internal async void GetJoinedTrips()
        {
            var json = await _publicTransportRepository.GetJoinedTrips();
            var joinedTrips = (string)JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<List<JoinedTripsModel>>(joinedTrips);

            data = data.OrderBy(x => x.BusLineName).ToList();

            App.Current.Properties["JoinedTrips"] = _timeTableService.JoinedTripsMapper(data);
        }

        internal async void GetBusStops()
        {
            var json = await _publicTransportRepository.GetBusStops();
            var busStopData = (string) JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);

            App.Current.Properties["BusStops"] = data;
        }

        internal async void GetBusLines()
        {
            var json = await _publicTransportRepository.GetBusLines();
            var busLineData = (string)JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<BusLineData>(busLineData);

            App.Current.Properties["BusLines"] = data;

            SortBusLines(data);
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
