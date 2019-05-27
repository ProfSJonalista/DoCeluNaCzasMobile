using System;
using System.Collections.Generic;
using System.Text;

namespace DoCeluNaCzasMobile.Models.TimeTable
{
    public class MinuteTimeTable
    {
        public string Id { get; set; }
        public string BusLineName { get; set; }
        public int StopId { get; set; }
        public List<int> RouteIds { get; set; }
        public Dictionary<DayType, Dictionary<int, List<int>>> MinuteDictionary { get; set; }
    }

    public enum DayType
    {
        Weekday, Saturday, Sunday
    }
}
