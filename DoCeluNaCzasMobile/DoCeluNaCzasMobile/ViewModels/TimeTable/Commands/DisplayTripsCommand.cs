using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using System;
using System.Windows.Input;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable.Commands
{
    public class DisplayTripsCommand : ICommand
    {
        private TimeTableViewModel _timeTableViewModel;

        public DisplayTripsCommand(TimeTableViewModel timeTableViewModel)
        {
            _timeTableViewModel = timeTableViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if(!(parameter is RouteViewModel busLine))
                return;

            NavigationService.Navigate(typeof(BusStopChoicePage), busLine.Name);
        }
    }
}
