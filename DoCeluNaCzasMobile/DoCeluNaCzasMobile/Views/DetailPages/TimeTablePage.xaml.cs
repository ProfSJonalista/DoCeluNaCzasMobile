using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTablePage : ContentPage
    {
        public TimeTablePage()
        {
            InitializeComponent();
        }

        private void lstView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var groupedRoutes = e.Item as GroupedRouteModel;
            var vm = BindingContext as TimeTableViewModel;
            vm.HideOrShowRoutes(groupedRoutes);
        }
    }
}
