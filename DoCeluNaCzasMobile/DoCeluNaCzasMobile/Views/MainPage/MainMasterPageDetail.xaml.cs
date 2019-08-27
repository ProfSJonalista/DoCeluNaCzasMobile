using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.ViewModels.RouteSearch;
using DoCeluNaCzasMobile.Views.DetailPages.RouteSearch;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPageDetail : ContentPage
    {
        public static RouteSearchViewModel RouteSearchViewModel { get; set; }

        public MainMasterPageDetail()
        {
            InitializeComponent();
            RouteSearchViewModel = new RouteSearchViewModel
            {
                Departure = true,
                UserChosenDate = DateTime.Now,
                UserChosenTime = DateTime.Now.TimeOfDay
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = RouteSearchViewModel;

            SetLabels();
        }

        void SwapButton_Clicked(object sender, EventArgs e)
        {
            var temp = RouteSearchViewModel.StartStop;
            RouteSearchViewModel.StartStop = RouteSearchViewModel.DestStop;
            RouteSearchViewModel.DestStop = temp;

            SetLabels();
        }

        async void SearchRouteButton_Clicked(object sender, EventArgs e)
        {
            if (RouteSearchViewModel.StartStop == null && RouteSearchViewModel.DestStop == null)
            {
                await DisplayAlert("Wybierz przystanek", "Wybierz przystanek początkowy i końcowy", "OK");
                return;
            }

            if (RouteSearchViewModel.StartStop == null)
            {
                await DisplayAlert("Wybierz przystanek", "Wybierz przystanek początkowy", "OK");
                return;
            }

            if (RouteSearchViewModel.DestStop == null)
            {
                await DisplayAlert("Wybierz przystanek", "Wybierz przystanek końcowy", "OK");
                return;
            }

            RouteSearchViewModel.ViewRoutes();
        }

        void StartStopChooseButton_OnClicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(typeof(ChooseStopPage), true);
        }

        void DestStopChooseButton_OnClicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(typeof(ChooseStopPage), false);
        }

        void SetLabels()
        {

            StartLabel.Text = RouteSearchViewModel.StartStop?.StopDesc ?? "Przystanek początkowy";
            DestLabel.Text = RouteSearchViewModel.DestStop?.StopDesc ?? "Przystanek końcowy";
        }
    }
}