using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable.Commands
{
    public class DisplayTripsCommand : ICommand
    {
        private TimeTableViewModel timeTableViewModel;

        public DisplayTripsCommand(TimeTableViewModel timeTableViewModel)
        {
            this.timeTableViewModel = timeTableViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var busLine = (RouteViewModel) parameter;
            


            App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }
    }
}
