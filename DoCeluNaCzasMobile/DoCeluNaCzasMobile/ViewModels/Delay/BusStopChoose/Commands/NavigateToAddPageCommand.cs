using System;
using System.Windows.Input;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose.Commands
{
    public class NavigateToAddPageCommand : ICommand
    {
        public NavigateToAddPageCommand(DelayBusStopChooseViewModel delayBusStopChooseViewModel)
        {
            DelayBusStopChooseViewModel = delayBusStopChooseViewModel;
        }

        public DelayBusStopChooseViewModel DelayBusStopChooseViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DelayBusStopChooseViewModel.NavigateToAddPage();
        }

        public event EventHandler CanExecuteChanged;
    }
}
