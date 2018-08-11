using DoCeluNaCzasMobile.Models;
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
            var busGroup = new GroupedRouteModel() { LongName = "Autobusy", ShortName = "aut" };
            var tramGrup = new GroupedRouteModel() { LongName = "Tramwaje", ShortName = "tram" };

            busGroup.Add(new RouteViewModel(400, "62"));
            busGroup.Add(new RouteViewModel(300, "45"));

            tramGrup.Add(new RouteViewModel(250, "42"));
            tramGrup.Add(new RouteViewModel(20, "2"));
            tramGrup.Add(new RouteViewModel(50, "4"));

            grouped.Add(busGroup);
            grouped.Add(tramGrup);

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