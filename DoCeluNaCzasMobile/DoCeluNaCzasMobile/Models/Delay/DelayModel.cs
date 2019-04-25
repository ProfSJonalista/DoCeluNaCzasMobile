using System;
using System.Collections.Generic;
using System.Text;

namespace DoCeluNaCzasMobile.Models.Delay
{
    public class DelayModel
    {
        public int RouteId { get; set; }
        public int TripId { get; set; }
        public string BusLineName { get; set; }
        public string Headsign { get; set; }
        public string DelayMessage { get; set; }
        public DateTime TheoreticalTime { get; set; }
        public DateTime EstimatedTime { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
