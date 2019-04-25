using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.Models.Delay;
using System;
using System.Collections.ObjectModel;

namespace DoCeluNaCzasMobile.Services.Delay
{
    public class ChooseBusStopDelayService
    {
        private readonly NavigationService _navigationService;
        private readonly DatabaseRepository _databaseRepository;

        public ChooseBusStopDelayService()
        {
            _navigationService = new NavigationService();
            _databaseRepository = new DatabaseRepository();
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType, int stopId = 0)
        {
            _navigationService.Navigate(pageType, null, stopId);
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
