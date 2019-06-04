using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePage : ContentPage
    {
        public ObservableCollection<Change> Items { get; set; }

        public ChangePage()
        {
            InitializeComponent();
        }

        public ChangePage(List<Change> changes)
        {
            InitializeComponent();
            Items = new ObservableCollection<Change>(changes);
            MyListView.ItemsSource = Items;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is Change change))
                return;

            NavigationService.Navigate(typeof(StopChangePage), change.StopChangeList);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
