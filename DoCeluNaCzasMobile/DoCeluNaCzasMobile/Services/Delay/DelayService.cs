using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DoCeluNaCzasMobile.Services.Delay
{
    public class DelayService
    {
        private readonly NavigationService _navigationService;
        private readonly DatabaseRepository _databaseRepository;

        public DelayService()
        {
            _navigationService = new NavigationService();
            _databaseRepository = new DatabaseRepository();
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType)
        {
            _navigationService.Navigate(pageType);
        }

        public void SetChooseBusStopModelCollection()
        {
            var busStopData = CacheService.Get<BusStopDataModel>(CacheKeys.BUS_STOP_DATA_MODEL);
            var joinedTrips = CacheService.Get<List<GroupedJoinedModel>>(CacheKeys.GROUPED_JOINED_MODEL_LIST);

            var chooseBusStopCollection = busStopData.Stops.Select(stop =>
            {
                var busLineNamesStringBuilder = new StringBuilder();
                var destinationsStringBuilder = new StringBuilder();

                foreach (var groupedJoinedModel in joinedTrips)
                {
                    foreach (var joinedTripModel in groupedJoinedModel.JoinedTripModels)
                    {
                        var joinedTripModelList = joinedTripModel.JoinedTrips.Where(x => x.Stops.Any(y => y.StopId == stop.StopId)).ToList();

                        foreach (var item in joinedTripModelList)
                        {
                            if (!destinationsStringBuilder.ToString().Contains(item.BusLineName))
                                busLineNamesStringBuilder.Append(item.BusLineName + ", ");

                            if (!destinationsStringBuilder.ToString().Contains(item.DestinationStopName))
                                destinationsStringBuilder.Append(item.DestinationStopName + ", ");
                        }
                    }
                }

                var busLines = busLineNamesStringBuilder.ToString();
                if (busLines.Length > 0)
                    busLines = busLines.Substring(0, busLines.Length - 2);

                var destinations = destinationsStringBuilder.ToString();
                if (destinations.Length > 0)
                    destinations = destinations.Substring(0, destinations.Length - 2); //removes extra ", " at the end of the string

                return new ChooseBusStopModel
                {
                    StopId = stop.StopId,
                    StopDesc = stop.StopDesc,
                    BusLineNames = busLines,
                    DestinationHeadsigns = destinations
                };
            }).ToList();

            CacheService.Save(new ObservableCollection<ChooseBusStopModel>(chooseBusStopCollection), CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
        }
    }
}
