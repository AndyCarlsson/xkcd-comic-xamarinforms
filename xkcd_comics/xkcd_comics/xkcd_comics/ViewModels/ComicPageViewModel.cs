using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;

namespace xkcd_comics.ViewModels
{
    class ComicPageViewModel : BaseViewModel
    {
        Random rnd = new Random();
      
        public int ComicNo { get; set; }
        private int comicMaxNo = 2319;

        private Comic _comic;
        public Comic Comic 
        {
            get { return _comic; }
            set
            {
                _comic = value;
                OnPropertyChanged("Comic");
            }
        }
        public ICommand GetRandomComicCommand { get; set; }
        public ICommand SaveToFavoritesCommand { get; set; }

        public ComicPageViewModel()
        {
            ComicNo = rnd.Next(1, comicMaxNo);

            Title = "Comic";
            Comic = new Comic();
            Comic = DataService.GetComicAsync(ComicNo);

            GetRandomComicCommand = new Command(GetRandomComic);
            SaveToFavoritesCommand = new Command(SaveToFavorites);
        }

        private void SaveToFavorites()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Comic>();
                connection.Insert(Comic);
            }
        }

        private void GetRandomComic()
        {
            ComicNo = rnd.Next(1, comicMaxNo);
            Comic = DataService.GetComicAsync(ComicNo);
        }
    }
}
