using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBusStopPage : ContentPage
    {
        public AddBusStopViewModel AddBusStopViewModel { get; set; }

        public AddBusStopPage()
        {
            InitializeComponent();
            AddBusStopViewModel = new AddBusStopViewModel();
            MyListView.ItemsSource = AddBusStopViewModel.Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                MyListView.ItemsSource = AddBusStopViewModel.Items;
            }
            else
            {
                MyListView.ItemsSource = AddBusStopViewModel.Items.Where(x =>
                    x.BusLineNames.Contains(e.NewTextValue) || x.StopDesc.Contains(e.NewTextValue));
            }
        }
    }
}
