using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.Login
{
    public class LoginViewModel
    {
        private readonly AuthService _apiServices = new AuthService();
        private readonly NavigationService _navigationService = new NavigationService();

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.LoginAsync(Username, Password);
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.Navigate(typeof(RegisterPage), "");
                });
            }
        }
    }
}
