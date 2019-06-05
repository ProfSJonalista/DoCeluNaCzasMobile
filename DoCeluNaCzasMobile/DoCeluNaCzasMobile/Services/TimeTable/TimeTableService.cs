using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.TimeTable
{
    public class TimeTableService
    {
        readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();

        internal GroupedRouteModel GetVehicles(string longName, Group group)
        {
            var groupedVm = new GroupedRouteModel()
            {
                Key = longName,
                ShortName = group.ToString()
            };

            var joinedTrips = CacheService.Get<List<GroupedJoinedModel>>(CacheKeys.GROUPED_JOINED_MODEL_LIST);
            var trips = joinedTrips.SingleOrDefault(x => x.Group == group);

            foreach (var trip in trips.JoinedTripModels)
            {
                groupedVm.Add(new RouteViewModel { Name = trip.BusLineName });
            }

            return groupedVm;
        }

        public async Task<List<MinuteTimeTable>> GetMinuteTimeTables(string busLineName)
        {
            var url = string.Format(Urls.MINUTE_TIME_TABLES_BY_BUS_LINE_NAME, busLineName);
            var json = await _publicTransportRepository.GetData(url);
            var minuteTimeTableList = JsonConvert.DeserializeObject<List<MinuteTimeTable>>(json);

            return minuteTimeTableList;
        }
    }
}
