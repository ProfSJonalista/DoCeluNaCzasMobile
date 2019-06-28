using DoCeluNaCzasMobile.DataAccess.Repository.Net;
using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.PublicTransport
{
    public class PublicTransportService
    {
        static readonly PublicTransportRepository _publicTransportRepository = new PublicTransportRepository();

        public static async void GetDataAsync()
        {
            await GetBusStopData();
            await GetJoinedTripList();
            await GetChooseBusStopModelCollection();
        }

        static async Task GetChooseBusStopModelCollection()
        {
            var chooseBusStopModelCollection = await GetDataAsync<ObservableCollection<ChooseBusStopModel>>(Urls.CHOOSE_BUS_STOP_OBSERVABLE_COLLECTION);
            CacheService.Save(chooseBusStopModelCollection, CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
        }

        static async Task GetBusStopData()
        {
            var busStopData = await GetDataAsync<BusStopDataModel>(Urls.BUS_STOP_DATA_MODEL);
            CacheService.Save(busStopData, CacheKeys.BUS_STOP_DATA_MODEL);
        }

        static async Task GetJoinedTripList()
        {
            var joinedTripsViewModelList = await GetDataAsync<List<GroupedJoinedModel>>(Urls.JOINED_TRIPS);
            CacheService.Save(joinedTripsViewModelList, CacheKeys.GROUPED_JOINED_MODEL_LIST);
        }

        static async Task<T> GetDataAsync<T>(string url)
        {
            var json = await _publicTransportRepository.DownloadDataAsync(url);
            var data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }
    }
}
