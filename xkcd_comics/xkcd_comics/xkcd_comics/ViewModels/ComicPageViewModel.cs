using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;
using xkcd_comics.Services;

namespace xkcd_comics.ViewModels
{
    class ComicPageViewModel : BaseViewModel
    {
        Random rnd = new Random();
        private int _comicMaxNo;

        public int ComicNo { get; set; }
        public int ComicMaxNo 
        {
            get { return _comicMaxNo; }
            set
            {
                _comicMaxNo = value;
                OnPropertyChanged("ComicMaxNo");
            }
        }

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
        public ICommand ImageClickedCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ComicPageViewModel()
        {
            _comicMaxNo = DataService.GetLatesComicAsync().Num;

            if (Comic == null)
            {
                ComicNo = rnd.Next(1, ComicMaxNo);
                Comic = new Comic();
                Comic = DataService.GetComicAsync(ComicNo);
            }
            
            GetRandomComicCommand = new Command(GetRandomComic);
            SaveToFavoritesCommand = new Command(SaveToFavorites);
            ImageClickedCommand = new Command(ImageClicked);
        }

        private void ImageClicked(object obj)
        {
            
        }

        private void SaveToFavorites()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Comic>();
                connection.Insert(Comic);
            }

            DependencyService.Get<IToastMessage>().LongAlert("Added to favorties");
        }
        private void GetRandomComic()
        {
            ComicNo = rnd.Next(1, ComicMaxNo);
            Comic = DataService.GetComicAsync(ComicNo);
        }

    }
}
