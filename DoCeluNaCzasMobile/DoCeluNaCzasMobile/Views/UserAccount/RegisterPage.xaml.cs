using DoCeluNaCzasMobile.Views.DetailPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.UserAccount
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private void OpenLoginPage_Clicked(object sender, EventArgs e)
        {
            var masterPage = new MainMasterPage();
            masterPage.Title = App.Current.MainPage.Title;
            masterPage.Detail = new NavigationPage(new UserAccountPage());

            App.Current.MainPage = masterPage;
        }
    }
}