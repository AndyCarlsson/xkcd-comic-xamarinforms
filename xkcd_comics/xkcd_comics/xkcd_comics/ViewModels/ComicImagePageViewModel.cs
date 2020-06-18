using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xkcd_comics.Models;

namespace xkcd_comics.ViewModels
{
    public class ComicImagePageViewModel : BaseViewModel
    {
        Comic _comic;
        public Comic Comic
        {
            get { return _comic; }
            set
            {
                _comic = value;
                OnPropertyChanged("Comic");
            }
        }

        public INavigation Navigation { get; set; }
        public ICommand ImageClickedCommand { get; set; }
        public ComicImagePageViewModel()
        {
            ImageClickedCommand = new Command(ImageClicked);
        }

        private void ImageClicked()
        {
            Navigation.PopModalAsync();
        }
    }
}
