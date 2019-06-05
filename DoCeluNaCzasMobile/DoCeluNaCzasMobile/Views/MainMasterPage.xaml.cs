using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using DoCeluNaCzasMobile.Views.DetailPages.Map;
using DoCeluNaCzasMobile.Views.DetailPages.Settings;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
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
                    page = new BusChoicePage();
                    break;

                case "Opóźnienia":
                    page = new DelaysBusStopChoosePage();
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
                    page = new MainMasterPageDetail();
                    item.Title = "Strona główna";
                    break;
            }

            page.Title = item.Title;
            return page;
        }
    }
}