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


            var joinedTrips = CacheService.Get<List<GroupedJoinedModel>>(CacheKeys.JOINED_TRIPS);
            var trips = joinedTrips.SingleOrDefault(x => x.Group == group);
            
            trips.JoinedTripModels.ForEach(x => groupedVm.Add(new RouteViewModel()
            {
                Name = x.BusLineName
            }));

            return groupedVm;
        }
    }
}
