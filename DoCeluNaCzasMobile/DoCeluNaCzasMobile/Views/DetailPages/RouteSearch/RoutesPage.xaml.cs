using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.Models.RouteSearch;
using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.ViewModels.RouteSearch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.RouteSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesPage : ContentPage
    {
        public ObservableCollection<Route> Items { get; set; }

        public RoutesPage()
        {
			InitializeComponent();
        }

        public RoutesPage(List<Route> routeList)
        {
            InitializeComponent();
            Items = new ObservableCollection<Route>(routeList);

            MyListView.ItemsSource = Items;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is Route route))
                return;

            NavigationService.Navigate(typeof(ChangePage), route.ChangeList);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
