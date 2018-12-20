using Xamarin.Forms;
using DoCeluNaCzasMobile.Views;
using DLToolkit.Forms.Controls;
using DoCeluNaCzasMobile.Services.PublicTransportServices;

namespace DoCeluNaCzasMobile
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            FlowListView.Init();

            MainPage = new MainMasterPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            PublicTransportService publicTransportService = new PublicTransportService();
            publicTransportService.GetDataWithSignalRAsync();
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
