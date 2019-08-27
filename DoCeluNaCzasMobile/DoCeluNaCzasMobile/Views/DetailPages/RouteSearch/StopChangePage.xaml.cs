using DoCeluNaCzasMobile.Models.RouteSearch;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using DoCeluNaCzasMobile.Services.RouteSearch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopChangePage : ContentPage
    {
        static Timer _timer;
        readonly RouteSearchDelayService _routeSearchDelayService;
        public ObservableCollection<StopChange> Items { get; set; }

        public StopChangePage() => InitializeComponent();

        public StopChangePage(List<StopChange> stopChanges, RouteSearchDelayService routeSearchDelayService)
        {
            InitializeComponent();
            _routeSearchDelayService = routeSearchDelayService;
            Items = new ObservableCollection<StopChange>(stopChanges);
            MyListView.ItemsSource = Items;
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
            
            if (!_routeSearchDelayService.IsConnected())
                await _routeSearchDelayService.StartConnection();

            Items = await _routeSearchDelayService.GetStopChangesEstimatedTimesOfArrival(Items);
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
            Items = await _routeSearchDelayService.GetStopChangesEstimatedTimesOfArrival(Items);

            Device.BeginInvokeOnMainThread(() =>
            {
                MyListView.ItemsSource = Items;
            });
        }

        public void StopTimer() => _timer.Stop();
    }
}
