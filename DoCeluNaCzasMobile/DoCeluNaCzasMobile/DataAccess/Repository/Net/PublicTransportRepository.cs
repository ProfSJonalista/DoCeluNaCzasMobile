﻿using System.Net.Http;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Net
{
    public class PublicTransportRepository
    {
        public async Task<string> GetJoinedTrips()
        {
            return await DownloadData(Urls.JOINED_TRIPS);
        }

        public async Task<string> GetBusStops()
        {
            return await DownloadData(Urls.BUS_STOPS);
        }
        
        private async Task<string> DownloadData(string url)
        {
            var data = "";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                data = json;
            }

            return data;
        }
    }
}