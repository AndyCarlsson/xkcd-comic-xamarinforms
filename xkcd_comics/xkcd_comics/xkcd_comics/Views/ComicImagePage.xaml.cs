using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.ViewModels;

namespace xkcd_comics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComicImagePage : ContentPage
    {
        public ComicImagePage()
        {
            InitializeComponent();
            //BindingContext = new ComicPageViewModel();
        }

        private void ImageClicked_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}