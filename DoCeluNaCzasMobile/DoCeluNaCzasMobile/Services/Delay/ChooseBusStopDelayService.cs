using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Navigation;
using System;
using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose;

namespace DoCeluNaCzasMobile.Services.Delay
{
    public class ChooseBusStopDelayService
    {
        readonly IDatabaseRepository _databaseRepository;

        public ChooseBusStopDelayService()
        {
            _databaseRepository = new DatabaseRepository();
        }

        public ObservableCollection<StopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType, StopModel stop = null)
        {
            NavigationService.Navigate(pageType, stop);
        }

        public void SaveToDb(StopModel item)
        {
            _databaseRepository.SaveStopModel(item);
        }

        public void DeleteFromDb(StopModel item)
        {
            _databaseRepository.Delete(item);
        }
    }
}
