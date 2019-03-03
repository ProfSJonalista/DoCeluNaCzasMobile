using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System.Collections.Generic;

namespace DoCeluNaCzasMobile.Services
{
    public class TimeTableService
    {
        internal GroupedRouteModel GetVehicles(string longName, string shortName)
        {
            var groupedVM = new GroupedRouteModel()
            {
                Key = longName,
                ShortName = shortName
            };

            var routeList = (List<Route>)App.Current.Properties[shortName];

            routeList.ForEach(x => groupedVM.Add(new RouteViewModel()
            {
                Id = x.RouteId,
                Name = x.RouteShortName
            }));

            return groupedVM;
        }
    }
}
