namespace DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers
{
    public class Urls
    {
        public static string SERVER_CONNECTION = "http://docelunaczaswebapi.com/";

        public static string TOKEN = SERVER_CONNECTION + "Token";
        public static string REGISTER = SERVER_CONNECTION + "api/Account/Register";
        public static string EMAIL_EXIST = SERVER_CONNECTION + "api/Account/EmailExist?email={0}";

        public static string BUS_STOP_DATA_MODEL = SERVER_CONNECTION + "api/BusStop";
        public static string GROUPED_JOINED_MODEL_LIST = SERVER_CONNECTION + "api/JoinedTrips";

        public static string MINUTE_TIME_TABLES_BY_BUS_LINE_NAME = SERVER_CONNECTION + "api/TimeTable?busLineName={0}";

        public static string ROUTE_SEARCH = SERVER_CONNECTION + "api/RouteSearch?startStopId={0}&destStopId={1}&departure={2}&desiredTime={3}";
    }
}