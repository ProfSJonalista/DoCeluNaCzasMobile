using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DoCeluNaCzasMobile.ViewModels.TimeTable
{
    public class RouteViewModel
    {
        public RouteViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GroupedRouteModel : ObservableCollection<RouteViewModel>
    {
        public string Key { get; set; }
        public string ShortName { get; set; }
        public bool IsVisible { get; set; }
    }
}
