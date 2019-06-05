using Xamarin.Forms;

namespace DoCeluNaCzasMobile.Services.Cache
{
    public static class CacheService
    {
        public static void Save<T>(T dataToSave, string cacheKey)
        {
            Application.Current.Properties[cacheKey] = dataToSave;
        }

        public static T Get<T>(string cacheKey)
        {
            return (T)Application.Current.Properties[cacheKey];
        }
    }
}
