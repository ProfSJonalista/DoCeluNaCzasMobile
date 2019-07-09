using System;
using System.Windows.Input;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose.Commands
{
    public class NavigateToAddPageCommand : ICommand
    {
        public DelayBusStopChooseViewModel DelayBusStopChooseViewModel { get; set; }

        public NavigateToAddPageCommand(DelayBusStopChooseViewModel delayBusStopChooseViewModel)
        {
            DelayBusStopChooseViewModel = delayBusStopChooseViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => DelayBusStopChooseViewModel.NavigateToAddPage();

        public event EventHandler CanExecuteChanged;
    }
}
