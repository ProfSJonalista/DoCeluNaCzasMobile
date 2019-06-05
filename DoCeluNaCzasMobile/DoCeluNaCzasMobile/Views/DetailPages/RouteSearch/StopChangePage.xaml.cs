using DoCeluNaCzasMobile.Models.RouteSearch;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopChangePage : ContentPage
    {
        public ObservableCollection<StopChange> Items { get; set; }

        public StopChangePage()
        {
            InitializeComponent();
        }

        public StopChangePage(List<StopChange> stopChanges)
        {
            InitializeComponent();
            Items = new ObservableCollection<StopChange>(stopChanges);
            MyListView.ItemsSource = Items;
        }

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
