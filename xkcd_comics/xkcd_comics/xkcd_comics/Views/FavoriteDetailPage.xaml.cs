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
    public partial class FavoriteDetailPage : ContentPage
    {
        FavoriteDetailPageViewModel _viewModel;
        public FavoriteDetailPage(Comic comic)
        {
            InitializeComponent();            
            _viewModel = new FavoriteDetailPageViewModel();
            _viewModel.SelectedComic = comic;
            BindingContext = _viewModel;
        }
    }
}