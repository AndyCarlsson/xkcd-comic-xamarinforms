using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;
using xkcd_comics.Services;
using xkcd_comics.Views;

namespace xkcd_comics.ViewModels
{
    class FavoritesPageViewModel : BaseViewModel
    {
        private Comic _selectedComic;
        private ObservableCollection<Comic> _favList;
        public ObservableCollection<Comic> FavList
        {
            get { return _favList; }
            set
            {
                _favList = value;
                OnPropertyChanged("FavList");
            }
        }
        public Comic SelectedComic
        {
            get { return _selectedComic; }
            set
            {
                if (_selectedComic != value)
                    _selectedComic = value;
                OnPropertyChanged("SelectedComic");

                Navigation.PushModalAsync(new FavoriteDetailPage(SelectedComic));
            }
        }

        public INavigation Navigation { get; set; }
        public ICommand DeleteSwipeCommand { get; set; }

        public FavoritesPageViewModel()
        {
            FavList = new ObservableCollection<Comic>();
            DeleteSwipeCommand = new Command(DeleteSwipe);
        }

        private void DeleteSwipe(object obj)
        {
            Comic comic = obj as Comic;

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.Delete(comic);

                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = $"Select count(*) FROM Comic WHERE Num = '{comic.Num}'";
                int count = Convert.ToInt32(cmd.ExecuteScalar<int>());

                if (count == 0)
                {
                    FavList.Remove(comic);
                    DependencyService.Get<IToastMessage>().LongAlert("Removed from Favorites");
                }
                else
                {
                    DependencyService.Get<IToastMessage>().LongAlert("Could not remove from Favorites");
                }
            }   
        }

        public void GetComicsFromDb()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Comic>();
                var list = connection.Table<Comic>().ToList();

                foreach (var comic in list)
                {
                    FavList.Insert(0, comic);
                }
            }
        }
    }
}
