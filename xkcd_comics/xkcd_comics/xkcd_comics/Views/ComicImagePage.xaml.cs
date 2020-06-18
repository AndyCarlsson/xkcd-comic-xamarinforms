using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.Models;
using xkcd_comics.ViewModels;

namespace xkcd_comics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComicImagePage : ContentPage
    {
        ComicImagePageViewModel _viewModel;
        public ComicImagePage(object obj)
        {
            InitializeComponent();
            _viewModel = new ComicImagePageViewModel();
            _viewModel.Comic = obj as Comic;
            _viewModel.Navigation = Navigation;
            BindingContext = _viewModel;
        }
    }
}