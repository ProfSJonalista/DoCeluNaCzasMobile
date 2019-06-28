using DoCeluNaCzasMobile.ViewModels.MainMasterPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoCeluNaCzasMobile.Views.MainPage
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
    }
}