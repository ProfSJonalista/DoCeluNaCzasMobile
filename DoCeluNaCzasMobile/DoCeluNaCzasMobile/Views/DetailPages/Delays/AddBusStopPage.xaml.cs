using DoCeluNaCzasMobile.ViewModels.Delay.AddBusStop;
using System.Linq;
using DoCeluNaCzasMobile.Models.Delay;
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

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var item = (ChooseBusStopModel)e.Item;
            AddBusStopViewModel.SaveToDb(item);

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
                    x.BusLineNames.ToLower().Contains(e.NewTextValue.ToLower()) || x.StopDesc.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}
