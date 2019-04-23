using DoCeluNaCzasMobile.ViewModels.Delay.BusStopChoose;
using System.Linq;
using DoCeluNaCzasMobile.Models.Delay;
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
            MyListView.IsVisible = visible;
            NoStopsLabel.IsVisible = !visible;
            MyListView.ItemsSource = items;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                MyListView.ItemsSource = DelayBusStopChooseViewModel.Items;
            }
            else
            {
                MyListView.ItemsSource = DelayBusStopChooseViewModel.Items.Where(x =>
                    x.BusLineNames.ToLower().Contains(e.NewTextValue.ToLower()) || x.StopDesc.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
        //przenosi do DelaysPage z odpowiednim stopId
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var stop = (ChooseBusStopModel) e.Item;

            DelayBusStopChooseViewModel.ChooseBusStopDelayService.Navigate(typeof(DelaysPage), stop.StopId);
        }
    }
}
