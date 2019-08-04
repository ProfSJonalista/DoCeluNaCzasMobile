using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Services.RouteSearch;
using System;

namespace DoCeluNaCzasMobile.ViewModels.RouteSearch
{
    public class RouteSearchViewModel
    {
        
        public StopModel StartStop { get; set; }
        public StopModel DestStop { get; set; }
        public bool Departure { get; set; }
        public DateTime UserChosenDate { get; set; }
        public TimeSpan UserChosenTime { get; set; }

        public void ViewRoutes()
        {
            var routeSearchService = new RouteSearchService(this);
            routeSearchService.ViewRoutes();
        }
    }
}
