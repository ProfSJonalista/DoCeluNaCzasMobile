using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using DoCeluNaCzasMobile.Models.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusStopChoicePage : ContentPage
	{
        JoinedTripModel Source { get; set; }
        readonly JoinedTripsModel _joinedTrips;
        List<MinuteTimeTable> _minuteTimeTableList;
        readonly TimeTableService _timeTableService = new TimeTableService();

        public BusStopChoicePage()
		{
			InitializeComponent();
        }

        public BusStopChoicePage(string busLineName)
        {
            InitializeComponent();
            
            var allJoinedTrips = CacheService.Get<List<GroupedJoinedModel>>(CacheKeys.GROUPED_JOINED_MODEL_LIST);
            var groupedModel = allJoinedTrips.SingleOrDefault(x => x.JoinedTripModels.Any(y => y.BusLineName.Equals(busLineName)));

            if(groupedModel != null)
                _joinedTrips = groupedModel.JoinedTripModels.SingleOrDefault(x => x.BusLineName.Equals(busLineName));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            JoinedTripsGrid.BindingContext = _joinedTrips;
            Source = _joinedTrips.JoinedTrips.FirstOrDefault();
            FirstStopNameLabel.Text = Source.FirstStopName;
            DestinationStopNameLabel.Text = Source.DestinationStopName;
            JoinedTripsListView.ItemsSource = Source.Stops;

            _minuteTimeTableList = await _timeTableService.GetMinuteTimeTables(Source.BusLineName);
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
            if(!(e.Item is JoinedStopModel stopModel))
                return;

            ((ListView)sender).SelectedItem = null;

            var stopToView = _minuteTimeTableList.FirstOrDefault(x => x.StopId == stopModel.StopId);

            NavigationService.Navigate(typeof(TimeTablePage.TimeTablePage), stopToView);
        }
    }
}