using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using System;
using System.Windows.Input;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable.Commands
{
    public class DisplayTripsCommand : ICommand
    {
        private TimeTableViewModel _timeTableViewModel;
        private readonly NavigationService _navigationService = new NavigationService();
        public DisplayTripsCommand(TimeTableViewModel timeTableViewModel)
        {
            this._timeTableViewModel = timeTableViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var busLine = (RouteViewModel)parameter;

            _navigationService.Navigate(typeof(BusStopChoicePage), busLine.Name);
        }
    }
}
