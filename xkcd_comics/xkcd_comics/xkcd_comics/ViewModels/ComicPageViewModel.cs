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
        public Comic Comic { get; set; }
        public ICommand GetRandomComicCommand { get; set; }
        public ComicPageViewModel()
        {
            Title = "Comic";
            Comic = new Comic();
            Comic = DataService.GetComicAsync("678");

            GetRandomComicCommand = new Command(GetRandomComic);
        }

        private void GetRandomComic()
        {
            Comic = DataService.GetComicAsync("100");
        }
    }
}
