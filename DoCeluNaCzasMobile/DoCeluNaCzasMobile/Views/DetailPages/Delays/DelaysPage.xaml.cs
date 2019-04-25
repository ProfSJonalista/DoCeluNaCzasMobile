﻿using System.Collections.ObjectModel;
using DoCeluNaCzasMobile.ViewModels.Delay.Delays;
using System.Collections.Specialized;
using System.Timers;
using System.Transactions;
using DoCeluNaCzasMobile.Models.Delay;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.DetailPages.Delays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelaysPage : ContentPage
    {
        private static Timer _timer;
        public DelayViewModel DelayViewModel { get; set; }
        public ObservableCollection<DelayModel> Items { get; set; }
        public DelaysPage()
        {
            InitializeComponent();
        }

        public DelaysPage(int stopId)
        {
            InitializeComponent();
            DelayViewModel = new DelayViewModel(stopId);
            Items = new ObservableCollection<DelayModel>();
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
            
            var visible = Items.Count > 0;

            DelayListView.IsVisible = visible;
            DelayListView.ItemsSource = Items;

            NoDelaysLabel.IsVisible = !visible;

            BindingContext = DelayViewModel;
            SetTimer();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DelayViewModel.StopConnection();
            StopTimer();
        }

        public void SetTimer()
        {
            const int timeInMilliseconds = 20000; //20 seconds
            _timer = new Timer(timeInMilliseconds);
            _timer.Elapsed += UpdateDataEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private async void UpdateDataEvent(object sender, ElapsedEventArgs e)
        {
            Items = await DelayViewModel.SetItems();

            Device.BeginInvokeOnMainThread(() =>
            {
                DelayListView.ItemsSource = Items;
            });
        }

        public void StopTimer()
        {
            _timer.Stop();
        }
    }
}
