using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Navigation;
using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType, ChooseBusStopModel stop = null)
        {
            NavigationService.Navigate(pageType, stop);
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
