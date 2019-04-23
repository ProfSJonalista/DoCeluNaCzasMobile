using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusStopChoicePage : ContentPage
	{
        private readonly JoinedTripsModel _joinedTrips;
        private JoinedTripModel Source { get; set; }
        private readonly NavigationService _navigationService;

        public BusStopChoicePage()
		{
			InitializeComponent();
        }

        public BusStopChoicePage(string busLineName)
        {
            InitializeComponent();
            //TODO change to sqldb
            _navigationService = new NavigationService();
            var allJoinedTrips = CacheService.Get<List<GroupedJoinedModel>>(CacheKeys.JOINED_TRIPS);
            var groupedModel = allJoinedTrips.SingleOrDefault(x => x.JoinedTripModels.Any(y => y.BusLineName.Equals(busLineName)));
            _joinedTrips = groupedModel.JoinedTripModels.SingleOrDefault(x => x.BusLineName.Equals(busLineName));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            JoinedTripsStackLayout.BindingContext = _joinedTrips;
            Source = _joinedTrips.JoinedTrips.FirstOrDefault();
            FirstStopNameLabel.Text = Source.FirstStopName;
            DestinationStopNameLabel.Text = Source.DestinationStopName;
            JoinedTripsListView.ItemsSource = Source.Stops;
        }

        private void ChangeDestinationButton_Clicked(object sender, EventArgs e)
        {
            Source = _joinedTrips.JoinedTrips.SingleOrDefault(x => !x.DestinationStopName.Equals(Source.DestinationStopName));
            FirstStopNameLabel.Text = Source.FirstStopName;
            DestinationStopNameLabel.Text = Source.DestinationStopName;
            JoinedTripsListView.ItemsSource = Source.Stops;
        }

        private void JoinedTripsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var busLineName = e.Item as JoinedStopModel;

            _navigationService.Navigate(typeof(TimeTableTabbedPage));
        }
    }
}