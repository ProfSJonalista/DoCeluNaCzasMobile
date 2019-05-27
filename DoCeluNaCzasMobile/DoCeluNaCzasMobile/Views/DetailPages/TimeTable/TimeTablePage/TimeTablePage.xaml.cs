using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.Models.TimeTable;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.TimeTable.TimeTablePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTablePage : ContentPage
    {
        readonly MinuteTimeTable _minuteTimeTable;
        public ObservableCollection<string> Items { get; set; }

        public TimeTablePage()
        {
            InitializeComponent();
        }

        public TimeTablePage(MinuteTimeTable minuteTimeTable)
        {
            InitializeComponent();

            _minuteTimeTable = minuteTimeTable;
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
