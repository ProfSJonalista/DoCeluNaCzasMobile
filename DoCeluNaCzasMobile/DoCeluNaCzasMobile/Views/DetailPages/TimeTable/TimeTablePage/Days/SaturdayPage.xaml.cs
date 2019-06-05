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
            Content = new HourAndMinuteGridView();
        }
    }
}