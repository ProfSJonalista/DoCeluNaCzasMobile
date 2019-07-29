using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.TimeTable;
using DoCeluNaCzasMobile.ViewModels.TimeTable.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable
{
    public class TimeTableViewModel : INotifyPropertyChanged
    {
        GroupedRouteModel _oldRoutes;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GroupedRouteModel> GroupedRoutes { get; set; }

        public TimeTableViewModel()
        {
            DisplayTripsCommand = new DisplayTripsCommand(this);
            var timeTableService = new TimeTableService();
            GroupedRoutes = new ObservableCollection<GroupedRouteModel>()
            {
                timeTableService.GetVehicles("Autobusy", Group.Buses),
                timeTableService.GetVehicles("Tramwaje", Group.Trams),
                timeTableService.GetVehicles("Trolejbusy", Group.Trolleys)
            };
        }

        public DisplayTripsCommand DisplayTripsCommand { get; set; }

        public void HideOrShowRoutes(GroupedRouteModel groupedRoutes)
        {
            if (_oldRoutes == groupedRoutes)
            {
                groupedRoutes.IsVisible = false;
                UpdateRoutes(groupedRoutes);
            }
            else
            {
                if (_oldRoutes != null)
                {
                    _oldRoutes.IsVisible = false;
                    UpdateRoutes(_oldRoutes);
                }

                groupedRoutes.IsVisible = true;
                UpdateRoutes(groupedRoutes);
            }

            _oldRoutes = groupedRoutes;
        }

        void UpdateRoutes(GroupedRouteModel groupedRoutes)
        {
            var id = GroupedRoutes.IndexOf(groupedRoutes);
            GroupedRoutes.Remove(groupedRoutes);
            GroupedRoutes.Insert(id, groupedRoutes);
        }

        void OnPropertyChanged(string propertyName)
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
        public string Name { get; set; }
    }
}
