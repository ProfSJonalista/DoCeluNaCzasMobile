using DoCeluNaCzasMobile.Views.DetailPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMasterPageMenuItem;
            if (item == null)
                return;

            Detail = new NavigationPage(getDetailPage(item));

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private Page getDetailPage(MainMasterPageMenuItem item)
        {
            Page page;

            switch (item.Title)
            {
                case "Strona główna":
                    page = new MainMasterPageDetail();
                    break;
                     
                case "Rozkład jazdy":
                    page = new TimeTablePage();
                    break;

                case "Opóźnienia":
                    page = new DelaysPage();
                    break;

                case "Mapa":
                    page = new MapPage();
                    break;

                case "Konto użytkownika":
                    page = new UserAccountPage();
                    break;

                case "Ustawienia":
                    page = new SettingsPage();
                    break;

                default:
                    page = (Page)Activator.CreateInstance(item.TargetType);
                    break;
            }

            page.Title = item.Title;
            return page;
        }
    }
}