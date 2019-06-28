using DoCeluNaCzasMobile.Services.Authorization;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.Register
{
    internal class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        readonly AuthService _authService = new AuthService();

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _authService.RegisterAsync(Email, Password, ConfirmPassword);

                    if (isSuccess)
                    {
                        NavigationService.Navigate(typeof(UserAccountPage));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Nieudana rejestracja", "Wystąpił błąd podczas rejestracji. Spróbuj ponownie później.", "OK");
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
