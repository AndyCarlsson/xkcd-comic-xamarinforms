using System;
using System.Collections.Generic;
using System.Text;
using xkcd_comics.Models;

namespace xkcd_comics.ViewModels
{
    class ComicPageViewModel : BaseViewModel
    {
        public Comic Comic { get; set; }
        public ComicPageViewModel()
        {
            Title = "Comic";
            Comic = new Comic();

            Comic = DataService.GetComicAsync("341");
        }

    }
}
