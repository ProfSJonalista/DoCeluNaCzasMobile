using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Net
{
    public class PublicTransportRepository
    {
        public async Task<string> GetChooseBusStopObservableCollection()
        {
            return await DownloadData(Urls.CHOOSE_BUS_STOP_OBSERVABLE_COLLECTION);
        }

        public async Task<string> GetJoinedTrips()
        {
            return await DownloadData(Urls.JOINED_TRIPS);
        }

        public async Task<string> GetBusStops()
        {
            return await DownloadData(Urls.BUS_STOPS);
        }

        public async Task<string> GetData(string modifiedUrl)
        {
            return await DownloadData(modifiedUrl);
        }

        static async Task<string> DownloadData(string url)
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
