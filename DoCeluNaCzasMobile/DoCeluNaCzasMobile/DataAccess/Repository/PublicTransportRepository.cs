using DoCeluNaCzasMobile.DataAccess.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess.Repository
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

        public async Task<string> GetBusLines()
        {
            return await DownloadData(Urls.BUS_LINES);
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
