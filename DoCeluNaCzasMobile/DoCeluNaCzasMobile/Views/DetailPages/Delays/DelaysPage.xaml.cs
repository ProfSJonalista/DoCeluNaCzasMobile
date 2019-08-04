using DoCeluNaCzasMobile.Models.Delay;
using DoCeluNaCzasMobile.Models.General;
using DoCeluNaCzasMobile.ViewModels.Delay.Delays;
using System.Collections.ObjectModel;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelaysPage : ContentPage
    {
        static Timer _timer;
        public DelayViewModel DelayViewModel { get; set; }
        public ObservableCollection<DelayModel> Items { get; set; }

        public DelaysPage() => InitializeComponent();

        public DelaysPage(StopModel stop)
        {
            InitializeComponent();
            Title = stop.StopDesc;
            Items = new ObservableCollection<DelayModel>();
            DelayViewModel = new DelayViewModel(stop.StopId);
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await DelayViewModel.StartConnection();
            DelayListView.RefreshAllowed = true;
            Items = await DelayViewModel.SetItems();

            SetVisibility();
            BindingContext = DelayViewModel;
            SetTimer();
        }

        void SetVisibility()
        {
            var visible = Items.Count > 0;

            DelayListView.IsVisible = visible;
            DelayListView.ItemsSource = Items;

            NoDelaysLabel.IsVisible = !visible;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DelayViewModel.StopConnection();
            StopTimer();
        }

        void SetTimer()
        {
            const int timeInMilliseconds = 20000; //20 seconds
            _timer = new Timer(timeInMilliseconds);
            _timer.Elapsed += UpdateDataEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        async void UpdateDataEvent(object sender, ElapsedEventArgs e)
        {
            Items = await DelayViewModel.SetItems();

            Device.BeginInvokeOnMainThread(() =>
            {
                SetVisibility();
                DelayListView.ItemsSource = Items;
            });
        }

        public void StopTimer() => _timer.Stop();
    }
}
