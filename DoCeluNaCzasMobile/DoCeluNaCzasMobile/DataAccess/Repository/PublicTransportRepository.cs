using DoCeluNaCzasMobile.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess.Repository
{
    public class PublicTransportRepository
    {
        public async Task<string> GetJoinedTrips()
        {
            return await DownloadData(Constants.JOINED_TRIPS);
        }

        public async Task<string> GetBusStops()
        {
            return await DownloadData(Constants.BUS_STOPS);
        }

        public async Task<string> GetBusLines()
        {
            return await DownloadData(Constants.BUS_LINES);
        }

        private async Task<string> DownloadData(string url)
        {
            var data = "";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                data = json;
            }

            return data;
        }
    }
}
