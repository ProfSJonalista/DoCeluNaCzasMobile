using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage.Days
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekdayPage : ContentPage
    {
        public WeekdayPage()
        {
            InitializeComponent();
            Content = new HourAndMinuteGridView();
        }
    }
}