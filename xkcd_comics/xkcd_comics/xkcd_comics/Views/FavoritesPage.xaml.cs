using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.Models;
using xkcd_comics.Services;
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
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            _viewModel.FavList.Clear();
            _viewModel.GetComicsFromDb();
        }

        private void FavListTapped_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new FavoriteDetailPage(e.Item as Comic));
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var si = sender as SwipeItem;
            var comic = si.CommandParameter as Comic;

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.Delete(comic);
            }
            _viewModel.FavList.Remove(comic);

            DependencyService.Get<IToastMessage>().LongAlert("Removed from Favorites");

        }
    }
}