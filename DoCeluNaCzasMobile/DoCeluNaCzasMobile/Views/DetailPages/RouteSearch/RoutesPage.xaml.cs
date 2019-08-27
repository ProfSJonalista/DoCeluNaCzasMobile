using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Services.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using DoCeluNaCzasMobile.Services.RouteSearch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesPage : ContentPage
    {
        static Timer _timer;
        readonly RouteSearchDelayService _routeSearchDelayService;
        public ObservableCollection<Route> Items { get; set; }
        public RoutesPage() => InitializeComponent();

        public RoutesPage(List<Route> routeList)
        {
            InitializeComponent();
            Items = new ObservableCollection<Route>(routeList);
            _routeSearchDelayService = new RouteSearchDelayService();
            //route = routeList.Find(x => x )
            MyListView.ItemsSource = Items;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            if (Items.Count == 0)
            {
                NoRoutesLabel.IsVisible = true;
                GridDirections.IsVisible = false;
                AvailableIcon.IsVisible = true;
                MyListView.IsVisible = false;
            }
            else
            {
                ChooseRouteLabel.IsVisible = true;
                RouteDirectionFrom.Text = Items[0].FirstStop.Name;
                RouteDirectionTo.Text = Items[0].LastStop.Name;
            }
            //RouteDirectionFromLabel.Text = "Nazwa przystanku";
            if (!_routeSearchDelayService.IsConnected())
                await _routeSearchDelayService.StartConnection();

            Items = await _routeSearchDelayService.GetRoutesEstimatedTimesOfArrival(Items);
            SetTimer();


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (_timer != null)
                StopTimer();
        }

        void SetTimer()
        {
            const int timeInMilliseconds = 20000; //20 seconds
            _timer = new Timer(timeInMilliseconds);
            _timer.Elapsed += UpdateDataEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        async void UpdateDataEvent(object sender, ElapsedEventArgs e)
        {
            Items = await _routeSearchDelayService.GetRoutesEstimatedTimesOfArrival(Items);

            Device.BeginInvokeOnMainThread(() =>
            {
                MyListView.ItemsSource = Items;
            });
        }

        public void StopTimer() => _timer.Stop();

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is Route route))
                return;

            NavigationService.Navigate(typeof(ChangePage), route.ChangeList, _routeSearchDelayService);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
