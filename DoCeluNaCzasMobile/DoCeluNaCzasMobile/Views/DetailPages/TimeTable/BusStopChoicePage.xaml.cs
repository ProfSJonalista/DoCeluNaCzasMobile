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
        JoinedTripsViewModel joinedTrips;
        StopTripDataViewModel Source { get; set; }
		public BusStopChoicePage()
		{
			InitializeComponent ();
		}

        public BusStopChoicePage(string busLineName)
        {
            InitializeComponent();
            var allJoinedTrips = (List<JoinedTripsViewModel>) App.Current.Properties["JoinedTrips"];

            joinedTrips = allJoinedTrips.Where(x => x.BusLineName.Equals(busLineName)).SingleOrDefault();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            JoinedTripsStackLayout.BindingContext = joinedTrips;
            Source = joinedTrips.JoinedTrips.FirstOrDefault();
            FirstStopNameLabel.Text = Source.FirstStopName;
            DestinationStopNameLabel.Text = Source.DestinationStopName;
            JoinedTripsListView.ItemsSource = Source.Stops;
        }

        private void ChangeDestinationButton_Clicked(object sender, EventArgs e)
        {
            Source = joinedTrips.JoinedTrips.Where(x => !x.DestinationStopName.Equals(Source.DestinationStopName)).SingleOrDefault();
            FirstStopNameLabel.Text = Source.FirstStopName;
            DestinationStopNameLabel.Text = Source.DestinationStopName;
            JoinedTripsListView.ItemsSource = Source.Stops;
        }

        private void JoinedTripsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var busLineName = e.Item as StopTripViewModel;

            var cos = busLineName.StopName;
            NavigationService.Navigate(typeof(TimeTableTabbedPage), "");
        }
    }
}