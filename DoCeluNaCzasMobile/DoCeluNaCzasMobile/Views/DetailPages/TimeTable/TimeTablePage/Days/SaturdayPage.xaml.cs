using DoCeluNaCzasMobile.Models.TimeTable;
using DoCeluNaCzasMobile.Services.Cache;
using DoCeluNaCzasMobile.Services.Cache.Keys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage.Days
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaturdayPage : ContentPage
    {
        public SaturdayPage()
        {
            InitializeComponent();

            var minuteTimeTable = CacheService.Get<MinuteTimeTable>(CacheKeys.MINUTE_TIME_TABLE);
            Content = new HourAndMinuteGridView(minuteTimeTable.MinuteDictionary[DayType.Saturday], DayType.Saturday);
        }
    }
}