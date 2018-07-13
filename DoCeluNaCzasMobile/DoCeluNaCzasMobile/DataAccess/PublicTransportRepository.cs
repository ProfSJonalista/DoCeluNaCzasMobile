using DoCeluNaCzasMobile.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess
{
    public class PublicTransportRepository
    {
        public static async Task<string> GetBusStops()
        {
            return await DownloadData(Constants.BUS_STOPS);
        }

        public static async Task<string> GetBusLines()
        {
            return await DownloadData(Constants.BUS_LINES);
        }

        private static async Task<string> DownloadData(string url)
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
