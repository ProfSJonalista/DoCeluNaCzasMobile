using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseStopPage : ContentPage
    {
        public bool Start { get; set; }

        public ObservableCollection<ChooseBusStopModel> Items { get; set; }

        public ChooseStopPage()
        {
            InitializeComponent();
        }

        public ChooseStopPage(bool start)
        {
            InitializeComponent();
            Start = start;
            Items = CacheService.Get<ObservableCollection<ChooseBusStopModel>>(CacheKeys.CHOOSE_BUS_STOP_MODEL_OBSERVABALE_COLLECTION);
            MyListView.ItemsSource = Items;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is ChooseBusStopModel chosenStop))
                return;

            if (Start)
                MainMasterPageDetail.RouteSearchViewModel.StartStop = chosenStop;
            else
                MainMasterPageDetail.RouteSearchViewModel.DestStop = chosenStop;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            NavigationService.ClosePage();
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                MyListView.ItemsSource = Items;
            }
            else
            {
                MyListView.ItemsSource = Items.Where(x =>
                    x.BusLineNames.ToLower().Contains(e.NewTextValue.ToLower()) || x.StopDesc.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}
