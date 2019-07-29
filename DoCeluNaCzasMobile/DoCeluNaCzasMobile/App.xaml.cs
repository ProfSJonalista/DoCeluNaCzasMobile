using DLToolkit.Forms.Controls;
using DoCeluNaCzasMobile.Services.PublicTransport;
using DoCeluNaCzasMobile.Views.MainPage;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile
{
    public partial class App : Application
    {
        public static string DATABASE_LOCATION = string.Empty;

        public App()
        {
            InitializeComponent();

            FlowListView.Init();
            MainPage = new MainMasterPage();
        }

        public App(string databaseLocation)
        {
            DATABASE_LOCATION = databaseLocation;
            FlowListView.Init();
            PublicTransportService.GetDataAsync();

            InitializeComponent();

            MainPage = new MainMasterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
