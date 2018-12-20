using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services;
using Plugin.Geolocator;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private double distance = 1.0;
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(new TimeSpan(0, 0, 0), 100);

            var position = await locator.GetPositionAsync();
            var center = new Position(position.Latitude, position.Longitude);

            var busStopData = (BusStopData)App.Current.Properties["BusStops"];
            
            DisplayInMap(busStopData);

            locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(center, Distance.FromKilometers(distance)));
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            await locator.StopListeningAsync();
        }

        private void DisplayInMap(BusStopData stops)
        {
            foreach (var stop in stops.Stops)
            {
                try
                {
                    var position = new Position(stop.StopLat, stop.StopLon);

                    var pin = new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = position,
                        Label = stop.StopDesc
                    };

                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre)
                {

                }
                catch (Exception e)
                {

                }
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Position(e.Position.Latitude, e.Position.Longitude);
            locationsMap.MoveToRegion(MapSpan.FromCenterAndRadius(center, Distance.FromKilometers(distance)));
        }
    }
}
