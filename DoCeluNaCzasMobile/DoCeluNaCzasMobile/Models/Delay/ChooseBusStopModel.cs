using SQLite;

namespace DoCeluNaCzasMobile.Models.Delay
{
    public class ChooseBusStopModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public string BusLineNames { get; set; }
        public string DestinationHeadsigns { get; set; }
    }
}
