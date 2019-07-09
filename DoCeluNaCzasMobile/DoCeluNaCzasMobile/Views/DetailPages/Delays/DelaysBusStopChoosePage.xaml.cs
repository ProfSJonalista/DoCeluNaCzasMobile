using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelaysBusStopChoosePage : ContentPage
    {
        public DelayBusStopChooseViewModel DelayBusStopChooseViewModel { get; set; }

        public DelaysBusStopChoosePage()
        {
            InitializeComponent();
            DelayBusStopChooseViewModel = new DelayBusStopChooseViewModel();
            BindingContext = DelayBusStopChooseViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var items = DelayBusStopChooseViewModel.GetUserBusStops();

            var visible = items.Count > 0;

            NoStopsLabel.IsVisible = !visible;
            BusStopListView.IsVisible = visible;
            BusStopListView.ItemsSource = items;
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                BusStopListView.ItemsSource = DelayBusStopChooseViewModel.Items;
            }
            else
            {
                BusStopListView.ItemsSource = DelayBusStopChooseViewModel.Items.Where(stop =>
                       stop.ChooseBusStopModel.BusLineNames.ToLower().Contains(e.NewTextValue.ToLower())
                    || stop.ChooseBusStopModel.StopDesc.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is ChooseBusStopViewModel stop))
                return;

            DelayBusStopChooseViewModel.Navigate(typeof(DelaysPage), stop.ChooseBusStopModel);
        }
    }
}
