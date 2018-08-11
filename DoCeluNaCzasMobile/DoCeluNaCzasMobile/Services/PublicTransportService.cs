using DoCeluNaCzasMobile.DataAccess;
using DoCeluNaCzasMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DoCeluNaCzasMobile.Services
{
    public class PublicTransportService
    {
        internal async static void GetBusStops()
        {
            var json = await PublicTransportRepository.GetBusStops();
            var busStopData = (string) JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);

            App.Current.Properties["BusStops"] = data;
        }

        internal async static void GetBusLines()
        {
            var json = await PublicTransportRepository.GetBusLines();
            var busLineData = (string)JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<BusLineData>(busLineData);

            App.Current.Properties["BusLines"] = data;

            SortBusLines(data);
        }

        private static void SortBusLines(BusLineData data)
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
