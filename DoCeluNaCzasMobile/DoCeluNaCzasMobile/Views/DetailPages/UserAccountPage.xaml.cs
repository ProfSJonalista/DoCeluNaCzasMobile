using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Views.UserAccount.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserAccountPage : ContentPage
	{
		public UserAccountPage ()
		{
			InitializeComponent ();

            User user;
            bool userLoggedIn = false;
            try
            {
                user = (User)App.Current.Properties["user"];
                userLoggedIn = user != null && !string.IsNullOrEmpty(user.access_token);
            }
            catch (Exception e)
            {
                
            }

            if (userLoggedIn)
                Content = new UserLoggedInView();
            else
                Content = new LoginAndRegistrationView();
		}
	}
}