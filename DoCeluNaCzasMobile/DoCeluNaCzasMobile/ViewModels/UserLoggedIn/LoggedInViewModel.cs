using DoCeluNaCzasMobile.Models;
using DoCeluNaCzasMobile.Services;
using DoCeluNaCzasMobile.Views.DetailPages;
using System.Windows.Input;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.UserLoggedIn
{
    public class LoggedInViewModel
    {
        private readonly NavigationService _navigationService = new NavigationService();
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    CacheService.Save(new User(), CacheKeys.USER);
                    _navigationService.Navigate(typeof(UserAccountPage));
                });
            }
        }
    }
}
