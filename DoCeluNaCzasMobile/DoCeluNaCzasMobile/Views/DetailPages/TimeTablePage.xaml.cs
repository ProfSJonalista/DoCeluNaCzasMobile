using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System.Collections.ObjectModel;

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

            grouped = new ObservableCollection<GroupedRouteModel>();

            grouped.Add(TimeTableService.GetVehicles("Autobusy", "buses"));
            grouped.Add(TimeTableService.GetVehicles("Tramwaje", "trams"));
            grouped.Add(TimeTableService.GetVehicles("Trolejbusy", "trolleys"));
            
            lstView.FlowItemsSource = grouped;
            lstView.IsGroupingEnabled = true;
            lstView.FlowGroupDisplayBinding = new Binding("Key");
            lstView.FlowGroupShortNameBinding = new Binding("ShortName");
        }
    }
}
