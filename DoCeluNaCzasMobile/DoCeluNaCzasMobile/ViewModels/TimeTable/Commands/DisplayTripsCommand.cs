﻿using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable.Commands
{
    public class DisplayTripsCommand : ICommand
    {
        private TimeTableViewModel timeTableViewModel;
        NavigationService _navigationService = new NavigationService();
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

            _navigationService.Navigate(typeof(BusStopChoicePage), busLine.Name);
        }
    }
}