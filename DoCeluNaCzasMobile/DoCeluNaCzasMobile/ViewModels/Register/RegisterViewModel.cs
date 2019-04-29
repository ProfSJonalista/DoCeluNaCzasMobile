using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.Register
{
    internal class RegisterViewModel
    {
        private readonly AuthService _apiServices = new AuthService();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    if (isSuccess)
                    {
                        NavigationService.Navigate(typeof(UserAccountPage));
                    }
                });
            }
        }

        public ICommand NavigateToLoginPageCommand
        {
            get
            {
                return new Command(() =>
                {
                    NavigationService.Navigate(typeof(UserAccountPage));
                });
            }
        }
    }
}
