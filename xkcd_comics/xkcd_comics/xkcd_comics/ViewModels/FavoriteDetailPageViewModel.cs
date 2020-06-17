using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;

namespace xkcd_comics.ViewModels
{
    public class FavoriteDetailPageViewModel : BaseViewModel
    {
        public Comic SelectedComic { get; set; }
        public ICommand ImageTappedCommand { get; set; }
        public INavigation Navigation { get; set; }

        public FavoriteDetailPageViewModel()
        {
            ImageTappedCommand = new Command(ImageTapped);
        }

        private void ImageTapped()
        {
            Navigation.PopModalAsync();
        }
    }
}
