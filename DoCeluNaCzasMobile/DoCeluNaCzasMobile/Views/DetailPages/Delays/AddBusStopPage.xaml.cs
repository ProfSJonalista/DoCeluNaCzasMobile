using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop;
using System.Linq;
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
            if(!(e.Item is StopModel stop))
                return;

            AddBusStopViewModel.SaveToDb(stop);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            var message = "Przystanek " + stop.StopDesc + " został dodany do listy";
            await DisplayAlert("Przystanek dodany", message, "OK");
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                MyListView.ItemsSource = AddBusStopViewModel.Items;
            }
            else
            {
                MyListView.ItemsSource = AddBusStopViewModel.Items.Where(x =>
                    x.BusLineNames.ToLower().Contains(e.NewTextValue.ToLower()) || x.StopDesc.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}
