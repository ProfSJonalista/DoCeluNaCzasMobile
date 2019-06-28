using DoCeluNaCzasMobile.Services.Authorization;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.Login
{
    public class LoginViewModel
    {
        private readonly AuthService _apiServices = new AuthService();

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var status = await _apiServices.LoginAsync(Username, Password);

                    if (status)
                    {
                        NavigationService.Navigate(typeof(UserAccountPage));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Nieudane logowanie", "Niepoprawny login lub hasło", "OK");
                    }
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigationService.Navigate(typeof(RegisterPage));
                });
            }
        }
    }
}
