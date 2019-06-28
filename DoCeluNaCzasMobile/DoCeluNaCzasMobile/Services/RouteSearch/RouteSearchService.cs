using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.ViewModels.RouteSearch;
using DoCeluNaCzasMobile.Views.DetailPages.RouteSearch;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DoCeluNaCzasMobile.Services.RouteSearch
{
    public class RouteSearchService
    {
        readonly RouteSearchViewModel _routeSearchViewModel;
        readonly PublicTransportRepository _publicTransportRepository;

        public RouteSearchService(RouteSearchViewModel routeSearchViewModel)
        {
            _routeSearchViewModel = routeSearchViewModel;
            _publicTransportRepository = new PublicTransportRepository();
        }


        public async void ViewRoutes()
        {
            var startStopId = _routeSearchViewModel.StartStop.StopId;
            var destStopId = _routeSearchViewModel.DestStop.StopId;
            var departure = _routeSearchViewModel.Departure;
            var desiredTime = _routeSearchViewModel.DesiredTime;
            var time = desiredTime.ToString("yyyy-MM-ddThh:mm:ss");

            var modifiedUrl = string.Format(Urls.ROUTE_SEARCH, startStopId, destStopId, departure, time);
            var json = await _publicTransportRepository.DownloadDataAsync(modifiedUrl);

            var routeList = JsonConvert.DeserializeObject<List<Route>>(json);

            NavigationService.Navigate(typeof(RoutesPage), routeList);
        }
    }
}
