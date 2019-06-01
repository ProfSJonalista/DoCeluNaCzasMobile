using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage.Days
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SundayPage : ContentPage
	{
		public SundayPage ()
		{
			InitializeComponent ();
            Content = new HourAndMinuteGridView();
        }
	}
}