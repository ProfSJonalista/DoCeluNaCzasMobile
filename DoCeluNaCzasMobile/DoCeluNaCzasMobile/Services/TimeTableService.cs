using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DoCeluNaCzasMobile.Services
{
    public class TimeTableService
    {
        readonly static Char[] CharactersToDeleteFromString = new Char[] { ' ', '+' };
        readonly static string ParenthesisToDelete = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";

        internal GroupedRouteModel GetVehicles(string longName, string shortName)
        {
            var groupedVM = new GroupedRouteModel()
            {
                Key = longName,
                ShortName = shortName
            };

            var routeList = (List<Route>)App.Current.Properties[shortName];

            routeList.ForEach(x => groupedVM.Add(new RouteViewModel(x.RouteId, x.RouteShortName)));

            return groupedVM;
        }

        public List<JoinedTripsViewModel> JoinedTripsMapper(List<JoinedTripsModel> joinedTripsModelList)
        {
            List<JoinedTripsViewModel> listToReturn = new List<JoinedTripsViewModel>();

            joinedTripsModelList.ForEach(x => listToReturn.Add(JoinTripsMapper(x)));

            return listToReturn;
        }

        private JoinedTripsViewModel JoinTripsMapper(JoinedTripsModel trips)
        {
            return new JoinedTripsViewModel()
            {
                BusLineName = trips.BusLineName,
                ContainsMultiplyTrips = trips.Trips.Count > 1,
                JoinedTrips = StopTripDataMapper(trips.Trips)
            };
        }

        private List<StopTripDataViewModel> StopTripDataMapper(List<StopTripDataModel> joinedTrips)
        {
            List<StopTripDataViewModel> listToReturn = new List<StopTripDataViewModel>();

            foreach (var stopTripData in joinedTrips)
            {
                var firstStopName = GetFirstStopName(stopTripData.TripHeadsign);
                var destinationStopName = GetDestinationStopName(stopTripData.TripHeadsign);

                StopTripDataViewModel stopTripDataViewModelToAdd = new StopTripDataViewModel()
                {
                    BusLineName = stopTripData.BusLineName,
                    FirstStopName = firstStopName,
                    DestinationStopName = destinationStopName,
                    MainRoute = stopTripData.MainRoute,
                    TechnicalTrip = stopTripData.TechnicalTrip,
                    ActivationDate = stopTripData.ActivationDate,
                    Stops = StopsMapper(stopTripData.Stops)
                };

                listToReturn.Add(stopTripDataViewModelToAdd);
            }

            return listToReturn;
        }

        private string GetFirstStopName(string tripHeadsign)
        {
            var belongsToGdynia = tripHeadsign.Contains(">");
            var index = 0;

            tripHeadsign = tripHeadsign.Trim(CharactersToDeleteFromString);

            if (belongsToGdynia)
                index = tripHeadsign.IndexOf('>') - 1;
            else
                index = tripHeadsign.IndexOf('-') - 1;

            var input = tripHeadsign.Substring(0, index);

            return Regex.Replace(input, ParenthesisToDelete, "");
        }

        private string GetDestinationStopName(string tripHeadsign)
        {
            var belongsToGdynia = tripHeadsign.Contains(">");
            var index = 0;

            if (belongsToGdynia)
                index = tripHeadsign.IndexOf('>') + 2;
            else
                index = tripHeadsign.IndexOf('-') + 2;

            var length = tripHeadsign.Length - index;

            var input = tripHeadsign.Substring(index, length);

            return Regex.Replace(input, ParenthesisToDelete, "");
        }

        private List<StopTripViewModel> StopsMapper(List<StopTripModel> stops)
        {
            List<StopTripViewModel> stopsViewModelList = new List<StopTripViewModel>();

            foreach (var stop in stops)
            {
                StopTripViewModel stopTripViewModelToAdd = new StopTripViewModel()
                {
                    RouteId = stop.RouteId,
                    TripId = stop.TripId,
                    AgencyId = stop.AgencyId,
                    DirectionId = stop.DirectionId,
                    StopId = stop.StopId,
                    StopName = stop.StopName,
                    TripHeadsign = stop.TripHeadsign,
                    OnDemand = stop.OnDemand,
                    StopLat = stop.StopLat,
                    StopLon = stop.StopLon,
                    StopSequence = stop.StopSequence,
                    RouteShortName = stop.RouteShortName,
                    BelongsToMainTrip = stop.BelongsToMainTrip
                };

                stopsViewModelList.Add(stopTripViewModelToAdd);
            }

            return stopsViewModelList;
        }
    }
}
