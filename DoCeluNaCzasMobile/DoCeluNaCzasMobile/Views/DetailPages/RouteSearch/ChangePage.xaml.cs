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
    public partial class ChangePage : ContentPage
    {
        static Timer _timer;
        readonly RouteSearchDelayService _routeSearchDelayService;
        public ObservableCollection<Change> Items { get; set; }

        public ChangePage()
        {
            InitializeComponent();
        }

        public ChangePage(List<Change> changes, RouteSearchDelayService routeSearchDelayService)
        {
            _routeSearchDelayService = routeSearchDelayService;
            InitializeComponent();
            Items = new ObservableCollection<Change>(changes);
            MyListView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_routeSearchDelayService.IsConnected())
                await _routeSearchDelayService.StartConnection();

            Items = await _routeSearchDelayService.GetChangesEstimatedTimesOfArrival(Items);
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
            Items = await _routeSearchDelayService.GetChangesEstimatedTimesOfArrival(Items);

            Device.BeginInvokeOnMainThread(() =>
            {
                MyListView.ItemsSource = Items;
            });
        }

        public void StopTimer() => _timer.Stop();

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is Change change))
                return;

            NavigationService.Navigate(typeof(StopChangePage), change.StopChangeList, _routeSearchDelayService);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
