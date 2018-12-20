using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusStopChoicePage : ContentPage
	{
        JoinedTripsViewModel _joinedTrips;
        StopTripDataViewModel _source { get; set; }
        NavigationService _navigationService;
        public BusStopChoicePage()
		{
			InitializeComponent();
            _navigationService = new NavigationService();
        }

        public BusStopChoicePage(string busLineName)
        {
            InitializeComponent();
            var allJoinedTrips = (List<JoinedTripsViewModel>) App.Current.Properties["JoinedTrips"];

            _joinedTrips = allJoinedTrips.Where(x => x.BusLineName.Equals(busLineName)).SingleOrDefault();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            JoinedTripsStackLayout.BindingContext = _joinedTrips;
            _source = _joinedTrips.JoinedTrips.FirstOrDefault();
            FirstStopNameLabel.Text = _source.FirstStopName;
            DestinationStopNameLabel.Text = _source.DestinationStopName;
            JoinedTripsListView.ItemsSource = _source.Stops;
        }

        private void ChangeDestinationButton_Clicked(object sender, EventArgs e)
        {
            _source = _joinedTrips.JoinedTrips.Where(x => !x.DestinationStopName.Equals(_source.DestinationStopName)).SingleOrDefault();
            FirstStopNameLabel.Text = _source.FirstStopName;
            DestinationStopNameLabel.Text = _source.DestinationStopName;
            JoinedTripsListView.ItemsSource = _source.Stops;
        }

        private void JoinedTripsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var busLineName = e.Item as StopTripViewModel;

            var cos = busLineName.StopName;
            _navigationService.Navigate(typeof(TimeTableTabbedPage), "");
        }
    }
}