using System.Net.Http;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Net
{
    public class PublicTransportRepository
    {
        static readonly HttpClient Client = new HttpClient();

        public async Task<string> DownloadDataAsync(string url)
        {
            return await Client.GetStringAsync(url);
        }
    }
}
