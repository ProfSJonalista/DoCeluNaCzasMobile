namespace DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers
{
    public class Urls
    {
        public static string SERVER_CONNECTION = "http://docelunaczaswebapi.com/";

        public static string TOKEN = SERVER_CONNECTION + "Token";
        public static string REGISTER = SERVER_CONNECTION + "api/Account/Register";
        public static string AUTHORIZED_VALUES = SERVER_CONNECTION + "api/AuthorizedValues";

        public static string BUS_STOP_DATA_MODEL = SERVER_CONNECTION + "api/BusStop";
        public static string JOINED_TRIPS = SERVER_CONNECTION + "api/JoinedTrips";
        public static string CHOOSE_BUS_STOP_OBSERVABLE_COLLECTION = SERVER_CONNECTION + "api/ChooseBusStop";

        public static string MINUTE_TIME_TABLES_BY_BUS_LINE_NAME = SERVER_CONNECTION + "api/TimeTable?busLineName={0}";

        public static string ROUTE_SEARCH = SERVER_CONNECTION +"api/RouteSearch?startStopId={0}&destStopId={1}&departure={2}&desiredTime={3}";
    }
}