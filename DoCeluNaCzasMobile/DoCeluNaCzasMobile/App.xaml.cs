﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using DoCeluNaCzasMobile.Views;
using DoCeluNaCzasMobile.Services;

namespace DoCeluNaCzasMobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new MainMasterPage();
            
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            PublicTransportService.GetBusStops();
            PublicTransportService.GetBusLines();
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
