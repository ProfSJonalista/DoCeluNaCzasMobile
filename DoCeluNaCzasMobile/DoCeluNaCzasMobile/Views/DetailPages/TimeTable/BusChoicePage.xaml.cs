using DoCeluNaCzasMobile.ViewModels.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusChoicePage : ContentPage
    {
        public BusChoicePage()
        {
            InitializeComponent();
        }

        void lstView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var groupedRoutes = e.Item as GroupedRouteModel;
            var vm = BindingContext as TimeTableViewModel;
            vm.HideOrShowRoutes(groupedRoutes);
        }
    }
}
