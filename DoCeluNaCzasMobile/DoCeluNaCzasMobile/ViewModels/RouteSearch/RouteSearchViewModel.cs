using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.RouteSearch;
using System;

namespace DoCeluNaCzasMobile.ViewModels.RouteSearch
{
    public class RouteSearchViewModel
    {
        
        public ChooseBusStopModel StartStop { get; set; }
        public ChooseBusStopModel DestStop { get; set; }
        public bool Departure { get; set; }
        public DateTime DesiredTime { get; set; }
        public DateTime UserChosenDate { get; set; }
        public TimeSpan UserChosenTime { get; set; }

        public void SetDesiredTime()
        {
            DesiredTime = UserChosenDate + UserChosenTime;
        }

        public void ViewRoutes()
        {
            var routeSearchService = new RouteSearchService(this);
            routeSearchService.ViewRoutes();
        }
    }
}
