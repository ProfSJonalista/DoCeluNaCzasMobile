using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Services;
using DLToolkit.Forms.Controls;

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
            PublicTransportService.GetData();
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
