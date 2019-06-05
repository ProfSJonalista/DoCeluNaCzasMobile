using DoCeluNaCzasMobile.Models.Authorization;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using DoCeluNaCzasMobile.Services.Navigation;
using DoCeluNaCzasMobile.Views.DetailPages.UserAccount;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoCeluNaCzasMobile.ViewModels.UserLoggedIn
{
    public class LoggedInViewModel
    {
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    CacheService.Save(new User(), CacheKeys.USER);
                    NavigationService.Navigate(typeof(UserAccountPage));
                });
            }
        }
    }
}
