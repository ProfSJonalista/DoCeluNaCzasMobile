using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Services.HubServices;
using DoCeluNaCzasMobile.Services.HubServices.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.RouteSearch
{
    public class RouteSearchDelayService
    {
        readonly HubService _hubService;

        public RouteSearchDelayService()
        {
            _hubService = new HubService(HubNames.DELAYS_HUB);
        }

        public async Task StartConnection() => await _hubService.StartConnection();

        public bool IsConnected() => _hubService.IsConnected();

        public void StopConnection() => _hubService.StopConnection();

        public async Task<ObservableCollection<Route>> GetRoutesEstimatedTimesOfArrival(ObservableCollection<Route> routes)
        {
            foreach (var route in routes)
            {
                route.FirstStop = await DoAsync(route.FirstStop);
                route.LastStop = await DoAsync(route.LastStop);
            }

            return routes;
        }

        public async Task<ObservableCollection<Change>> GetChangesEstimatedTimesOfArrival(ObservableCollection<Change> changes)
        {
            foreach (var change in changes)
            {
                change.FirstStop = await DoAsync(change.FirstStop);
                change.LastStop = await DoAsync(change.LastStop);
            }

            return changes;
        }

        public async Task<ObservableCollection<StopChange>> GetStopChangesEstimatedTimesOfArrival(ObservableCollection<StopChange> stops)
        {
            var listOfTasks = new List<Task<StopChange>>();

            foreach (var stopChange in stops)
            {
                listOfTasks.Add(DoAsync(stopChange));
            }

            return new ObservableCollection<StopChange>(await Task.WhenAll(listOfTasks));
        }

        async Task<StopChange> DoAsync(StopChange stop)
        {
            return await _hubService.GetData<StopChange, StopChange>(HubNames.GET_ONE_DELAY, stop);
        }
    }
}
