using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;
using xkcd_comics.Services;
using xkcd_comics.Views;

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
        public ICommand ComicClickedCommand { get; set; }
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
            //ComicClickedCommand = new Command(ComicClicked);
        }

        //private void ComicClicked(object obj)
        //{
        //    Navigation.PushModalAsync(new ComicImagePage(obj as Comic));
        //}

        private void SaveToFavorites()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = $"Select count(*) FROM Comic WHERE Num = '{Comic.Num}'";
                int count = Convert.ToInt32(cmd.ExecuteScalar<int>());

                if (count == 0)
                {
                    connection.CreateTable<Comic>();
                    connection.Insert(Comic);
                    DependencyService.Get<IToastMessage>().LongAlert("Added to favorties");
                }
                else
                {
                    DependencyService.Get<IToastMessage>().LongAlert("Already added to favorites");
                }
            }    
        }

        private void GetRandomComic()
        {
            ComicNo = rnd.Next(1, ComicMaxNo);
            Comic = DataService.GetComicAsync(ComicNo);            
        }

    }
}
