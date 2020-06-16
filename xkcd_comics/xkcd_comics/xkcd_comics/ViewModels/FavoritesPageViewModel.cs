using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;

namespace xkcd_comics.ViewModels
{
    class FavoritesPageViewModel : BaseViewModel
    {
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
        public ICommand ListItemTappedCommand { get; }

        public FavoritesPageViewModel()
        {
            FavList = new ObservableCollection<Comic>();
            Title = "Favorites";
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
