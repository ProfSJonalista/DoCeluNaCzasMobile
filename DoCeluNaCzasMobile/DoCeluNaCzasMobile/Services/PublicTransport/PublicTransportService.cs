using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransport
{
    public class PublicTransportService
    {
        static readonly PublicTransportRepository PublicTransportRepository = new PublicTransportRepository();

        public static async void GetDataAsync()
        {
            await GetBusStopData();
            await GetJoinedTripList();
        }

        static async Task GetBusStopData() =>
            await GetDataAsync<BusStopDataModel>(Urls.BUS_STOP_DATA_MODEL, CacheKeys.BUS_STOP_DATA_MODEL);

        static async Task GetJoinedTripList() =>
            await GetDataAsync<List<GroupedJoinedModel>>(Urls.GROUPED_JOINED_MODEL_LIST, CacheKeys.GROUPED_JOINED_MODEL_LIST);

        static async Task GetDataAsync<T>(string url, string cacheKey)
        {
            var json = await PublicTransportRepository.DownloadDataAsync(url);
            var data = JsonConvert.DeserializeObject<T>(json);

            CacheService.Save(data, cacheKey);
        }
    }
}
