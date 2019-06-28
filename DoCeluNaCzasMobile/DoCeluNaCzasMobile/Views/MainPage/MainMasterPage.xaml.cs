using System.Threading.Tasks;
using DoCeluNaCzasMobile.Models.MainPage;
using DoCeluNaCzasMobile.Views.DetailPages.Delays;
using DoCeluNaCzasMobile.Views.DetailPages.Map;
using DoCeluNaCzasMobile.Views.DetailPages.Settings;
using DoCeluNaCzasMobile.Views.DetailPages.TimeTable;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainMasterPageMenuItem item))
                return;

            MasterPage.ListView.SelectedItem = null;

            //wsadzone w to bo był widoczny lag - teraz jest mniejszy
            await Task.Factory.StartNew(() =>
            {
                Detail = new NavigationPage(GetDetailPage(item));
            });

            IsPresented = false;
        }

        static Page GetDetailPage(MainMasterPageMenuItem item)
        {
            Page page;

            switch (item.Id)
            {
                case 1:
                    page = new BusChoicePage();
                    break;

                case 2:
                    page = new DelaysBusStopChoosePage();
                    break;

                case 3:
                    page = new MapPage();
                    break;

                case 4:
                    page = new UserAccountPage();
                    break;

                case 5:
                    page = new SettingsPage();
                    break;

                default:
                    page = new MainMasterPageDetail();
                    break;
            }

            page.Title = item.Title;
            return page;
        }
    }
}