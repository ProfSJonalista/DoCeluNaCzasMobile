using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System.Collections.Generic;
using System.Linq;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;

namespace DoCeluNaCzasMobile.Services
{
    public class TimeTableService
    {
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
    }
}
