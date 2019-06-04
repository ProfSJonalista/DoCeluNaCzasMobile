using DLToolkit.Forms.Controls;
using DoCeluNaCzasMobile.Services.PublicTransportServices;
using DoCeluNaCzasMobile.Views;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            FlowListView.Init();
            MainPage = new MainMasterPage();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;
            FlowListView.Init();

            var publicTransportService = new PublicTransportService();
            publicTransportService.GetDataWithSignalRAsync();

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
