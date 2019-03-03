using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.TimeTable.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable
{
    public class TimeTableViewModel : INotifyPropertyChanged
    {
        private GroupedRouteModel _oldRoutes;
        TimeTableService _timeTableService;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GroupedRouteModel> GroupedRoutes { get; set; }

        public TimeTableViewModel()
        {
            DisplayTripsCommand = new DisplayTripsCommand(this);
            _timeTableService = new TimeTableService();
            GroupedRoutes = new ObservableCollection<GroupedRouteModel>()
            {
                _timeTableService.GetVehicles("Autobusy", "buses"),
                _timeTableService.GetVehicles("Tramwaje", "trams"),
                _timeTableService.GetVehicles("Trolejbusy", "trolleys")
            };
        }

        public DisplayTripsCommand DisplayTripsCommand { get; set; }

        public void HideOrShowRoutes(GroupedRouteModel groupedRoutes)
        {
            if(_oldRoutes == groupedRoutes)
            {
                groupedRoutes.IsVisible = false;
                UpdateRoutes(groupedRoutes);
            }
            else
            {
                if(_oldRoutes != null)
                {
                    _oldRoutes.IsVisible = false;
                    UpdateRoutes(_oldRoutes);
                }

                groupedRoutes.IsVisible = true;
                UpdateRoutes(groupedRoutes);
            }

            _oldRoutes = groupedRoutes;
        }

        private void UpdateRoutes(GroupedRouteModel groupedRoutes)
        {
            var id = GroupedRoutes.IndexOf(groupedRoutes);
            GroupedRoutes.Remove(groupedRoutes);
            GroupedRoutes.Insert(id, groupedRoutes);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GroupedRouteModel : ObservableCollection<RouteViewModel>
    {
        public string Key { get; set; }
        public string ShortName { get; set; }
        public bool IsVisible { get; set; }
    }

    public class RouteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
