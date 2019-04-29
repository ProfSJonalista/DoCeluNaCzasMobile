using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTablePage : ContentPage
    {
        public TimeTablePage ()
        {
            InitializeComponent();
        }

        public TimeTablePage(int routeId)
        {
            InitializeComponent();
        }
    }
}