using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.ViewModels;

namespace xkcd_comics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        FavoritesPageViewModel _viewModel;
        public FavoritesPage()
        {
            InitializeComponent();
            _viewModel = new FavoritesPageViewModel();
            _viewModel.Navigation = Navigation;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            _viewModel.FavList.Clear();
            _viewModel.GetComicsFromDb();
        }
    }
}