using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.DataAccess.Repository.Net
{
    public class PublicTransportRepository
    {
        static readonly HttpClient Client = new HttpClient();

        public async Task<string> DownloadDataAsync(string url)
        {
            try
            {
                return await Client.GetStringAsync(url);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
