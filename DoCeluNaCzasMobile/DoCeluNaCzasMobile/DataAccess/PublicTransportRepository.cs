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
        public static async Task<String> GetBusStops()
        {
            return await DownloadData(Constants.BUS_STOPS);
        }

        private async static Task<string> DownloadData(string url)
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
