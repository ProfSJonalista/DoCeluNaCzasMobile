using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.Models.Delay;
using System;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.Services.Delay
{
    public class ChooseBusStopDelayService
    {
        private readonly DatabaseRepository _databaseRepository;

        public ChooseBusStopDelayService()
        {
            _databaseRepository = new DatabaseRepository();
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType, int stopId = 0)
        {
            NavigationService.Navigate(pageType, stopId);
        }

        public void SaveToDb(ChooseBusStopModel item)
        {
            _databaseRepository.SaveStopModel(item);
        }

        public void DeleteFromDb(ChooseBusStopModel item)
        {
            _databaseRepository.Delete(item);
        }
    }
}
