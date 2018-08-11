using System;
using System.Collections.Generic;
using System.Text;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;

namespace DoCeluNaCzasMobile.Services
{
    public class TimeTableService
    {
        internal static GroupedRouteModel GetVehicles(string longName, string shortName)
        {
            var groupedVM = new GroupedRouteModel()
            {
                LongName = longName,
                ShortName = shortName
            };

            List<Route> routeList = (List<Route>)App.Current.Properties[shortName];

            routeList.ForEach(x => groupedVM.Add(new RouteViewModel(x.RouteId, x.RouteShortName)));

            return groupedVM;
        }
    }
}
