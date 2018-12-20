using System;
using System.Collections.Generic;
using System.Text;

namespace DoCeluNaCzasMobile.DataAccess.Helpers
{
    public class Constants
    {
        public static string TOKEN = "http://docelunaczaswebapi.com/Token";
        public static string REGISTER = "http://docelunaczaswebapi.com/api/Account/Register";
        public static string AUTHORIZED_VALUES = "http://docelunaczaswebapi.com/api/AuthorizedValues";

        public static string BUS_STOPS = "http://docelunaczaswebapi.com/api/BusStop?hasData=false";
        public static string BUS_LINES = "http://docelunaczaswebapi.com/api/BusLine?hasData=false";
        public static string JOINED_TRIPS = "http://docelunaczaswebapi.com/api/JoinedTrips?hasData=false";
    }
}
