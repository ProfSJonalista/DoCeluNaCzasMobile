using System;
using System.Collections.Generic;
using System.Text;

namespace DoCeluNaCzasMobile.Models
{
    public class BusLineData
    {
        public string Day { get; set; }
        public string LastUpdate { get; set; }
        public IList<Route> Routes { get; set; }
    }

    public class Route
    {
        public int RouteId { get; set; }
        public int AgencyId { get; set; }
        public string RouteShortName { get; set; }
        public string RouteLongName { get; set; }
        public string ActivationDate { get; set; }
    }
}
