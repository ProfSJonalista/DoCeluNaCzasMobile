using DoCeluNaCzasMobile.DataAccess;
using DoCeluNaCzasMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services
{
    public class PublicTransportService
    {
        internal async static Task<BusStopData> GetBusStops()
        {
            var json = await PublicTransportRepository.GetBusStops();
            var busStopData = (string) JsonConvert.DeserializeObject(json);

            var data = JsonConvert.DeserializeObject<BusStopData>(busStopData);
            
            return data;
        }
    }
}
