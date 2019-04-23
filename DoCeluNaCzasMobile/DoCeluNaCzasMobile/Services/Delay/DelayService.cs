using DoCeluNaCzasMobile.DataAccess.Repository.Database;
using DoCeluNaCzasMobile.ViewModels.Delay;
using System;
using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.Models.Delay;

namespace DoCeluNaCzasMobile.Services.Delay
{
    public class DelayService
    {
        private readonly NavigationService _navigationService;
        private readonly DatabaseRepository _databaseRepository;

        public DelayService()
        {
            _navigationService = new NavigationService();
            _databaseRepository = new DatabaseRepository();
        }

        public ObservableCollection<ChooseBusStopModel> GetUserBusStops()
        {
            return _databaseRepository.GetUserBusStopObservableCollection();
        }

        public void Navigate(Type pageType)
        {
            _navigationService.Navigate(pageType);
        }
    }
}
