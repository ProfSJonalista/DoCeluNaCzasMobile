using DoCeluNaCzasMobile.Models.General.Shared;
using SQLite;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.Models.General
{
    public class BusStopDataModel : CommonModel
    {
        public ObservableCollection<StopModel> Stops { get; set; }
    }

    public class StopModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int StopId { get; set; }
        public string StopDesc { get; set; }
        public double StopLat { get; set; }
        public double StopLon { get; set; }
        public string BusLineNames { get; set; }
        public string DestinationHeadsigns { get; set; }
        public bool? TicketZoneBorder { get; set; }
        public bool? OnDemand { get; set; }
    }
}
