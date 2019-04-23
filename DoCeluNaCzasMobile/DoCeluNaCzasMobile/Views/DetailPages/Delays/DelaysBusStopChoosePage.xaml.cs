using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services.Delay;
using System;
using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.ViewModels.Delay;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelaysBusStopChoosePage : ContentPage
    {
        public DelaysBusStopChoosePage()
        {
            InitializeComponent();
            BindingContext = new DelayBusStopChooseViewModel();
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

        //przenosi do DelaysPage z odpowiednim stopId
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
