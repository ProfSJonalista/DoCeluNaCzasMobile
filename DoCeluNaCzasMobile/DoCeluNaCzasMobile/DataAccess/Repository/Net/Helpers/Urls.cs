namespace DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers
{
    public class Urls
    {
        public static string HUB_CONNECTION = "http://docelunaczaswebapi.com/";

        public static string TOKEN = "http://docelunaczaswebapi.com/Token";
        public static string REGISTER = "http://docelunaczaswebapi.com/api/Account/Register";
        public static string AUTHORIZED_VALUES = "http://docelunaczaswebapi.com/api/AuthorizedValues";

        public static string BUS_STOPS = "http://docelunaczaswebapi.com/api/BusStop";
        public static string JOINED_TRIPS = "http://docelunaczaswebapi.com/api/JoinedTrips";
        public static string CHOOSE_BUS_STOP_OBSERVABLE_COLLECTION = "http://docelunaczaswebapi.com/api/ChooseBusStop";

        public static string MINUTE_TIME_TABLES_BY_BUS_LINE_NAME = "http://docelunaczaswebapi.com/api/TimeTable?busLineName={0}";
    }
}