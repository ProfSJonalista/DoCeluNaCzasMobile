using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public MainMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMasterPageMenuItem> MenuItems { get; set; }

            public MainMasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMasterPageMenuItem>(new[]
                {
                    new MainMasterPageMenuItem { Id = 0, Title = "Strona główna" },
                    new MainMasterPageMenuItem { Id = 1, Title = "Rozkład jazdy" },
                    new MainMasterPageMenuItem { Id = 2, Title = "Opóźnienia" },
                    new MainMasterPageMenuItem { Id = 3, Title = "Mapa" },
                    new MainMasterPageMenuItem { Id = 4, Title = "Konto użytkownika" },
                    new MainMasterPageMenuItem { Id = 5, Title = "Ustawienia" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}