using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.ViewModels.Delay.Delays;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelaysPage : ContentPage
    {
        public DelayViewModel DelayViewModel { get; set; }
        public DelaysPage()
        {
            InitializeComponent();
        }

        public DelaysPage(int stopId)
        {
            InitializeComponent();
            DelayViewModel = new DelayViewModel(stopId);
            MyListView.ItemsSource = DelayViewModel.Items;
            BindingContext = DelayViewModel;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await DelayViewModel.StartConnection();
            DelayViewModel.SetTimer();
            DelayViewModel.SetItems();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DelayViewModel.StopConnection();
            DelayViewModel.StopTimer();
        }
    }
}
