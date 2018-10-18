﻿using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System;
using System.Collections.Generic;

namespace DoCeluNaCzasMobile.Services
{
    public class TimeTableService
    {
        internal static GroupedRouteModel GetVehicles(string longName, string shortName)
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

        public static List<JoinedTripsViewModel> JoinedTripsMapper(List<JoinedTripsModel> joinedTripsModelList)
        {
            List<JoinedTripsViewModel> listToReturn = new List<JoinedTripsViewModel>();

            joinedTripsModelList.ForEach(x => listToReturn.Add(JoinTripsMapper(x)));

            return listToReturn;
        }

        private static JoinedTripsViewModel JoinTripsMapper(JoinedTripsModel trips)
        {
            return new JoinedTripsViewModel()
            {
                BusLineName = trips.BusLineName,
                ContainsMultiplyTrips = trips.JoinedTrips.Count > 1,
                JoinedTrips = StopTripDataMapper(trips.JoinedTrips)
            };
        }

        private static List<StopTripDataViewModel> StopTripDataMapper(List<StopTripDataModel> joinedTrips)
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

        private static string GetFirstStopName(string tripHeadsign)
        {
            var belongsToGdynia = tripHeadsign.Contains(">");
            var firstStopName = "";
            var index = 0;

            if (belongsToGdynia)
                index = tripHeadsign.IndexOf('>') - 2;
            else
                index = tripHeadsign.IndexOf('-') - 2;

            try
            {
                firstStopName = tripHeadsign.Substring(0, index - 2);
            }
            catch(Exception e)
            {

            }

            return firstStopName;
        }

        private static string GetDestinationStopName(string tripHeadsign)
        {
            var belongsToGdynia = tripHeadsign.Contains(">");
            var destinationStopName = "";
            var index = 0;

            if (belongsToGdynia)
                index = tripHeadsign.IndexOf('>') + 2;
            else
                index = tripHeadsign.IndexOf('-') + 2;

            var length = tripHeadsign.Length - index;
            try
            {
                destinationStopName = tripHeadsign.Substring(index, length);
            }
            catch (Exception e)
            {

            }

            return destinationStopName;
        }

        private static List<StopTripViewModel> StopsMapper(List<StopTripModel> stops)
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
