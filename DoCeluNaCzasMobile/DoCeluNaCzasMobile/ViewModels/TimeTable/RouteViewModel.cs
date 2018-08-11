using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable
{
    public class RouteViewModel
    {
        public RouteViewModel(int routeId, string routeShortName)
        {
            RouteId = routeId;
            RouteShortName = routeShortName;
        }

        public int RouteId { get; set; }
        public string RouteShortName { get; set; }
    }

    public class GroupedRouteModel : ObservableCollection<RouteViewModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}
