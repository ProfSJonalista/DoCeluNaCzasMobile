using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTablePage : ContentPage
    {
        private ObservableCollection<GroupedRouteModel> grouped { get; set; }
        public TimeTablePage()
        {
            InitializeComponent();
            var lstView = new ListView();
            grouped = new ObservableCollection<GroupedRouteModel>();

            grouped.Add(TimeTableService.GetVehicles("Autobusy", "buses"));
            grouped.Add(TimeTableService.GetVehicles("Tramwaje", "trams"));
            grouped.Add(TimeTableService.GetVehicles("Trolejbusy", "trolleys"));

            lstView.ItemsSource = grouped;
            lstView.IsGroupingEnabled = true;
            lstView.GroupDisplayBinding = new Binding("LongName");
            lstView.GroupShortNameBinding = new Binding("ShortName");

            lstView.ItemTemplate = new DataTemplate(typeof(TextCell));
            lstView.ItemTemplate.SetBinding(TextCell.TextProperty, "RouteShortName");

            Content = lstView;
        }
    }
}