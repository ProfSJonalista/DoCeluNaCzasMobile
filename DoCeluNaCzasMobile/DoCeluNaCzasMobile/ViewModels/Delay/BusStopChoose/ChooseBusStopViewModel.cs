using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.General;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose
{
    public class ChooseBusStopViewModel
    {
        public StopModel StopModel { get; set; }
        public DelayBusStopChooseViewModel DelayBusStopChooseViewModel { get; set; }

        public ICommand DeleteStopCommand
        {
            get
            {
                return new Command(() =>
                {
                    DelayBusStopChooseViewModel.DeleteStop(StopModel);
                });
            }
        }
    }
}
