using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.ViewModels;

namespace xkcd_comics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComicPage : ContentPage
    {
        ComicPageViewModel _viewModel;
        public ComicPage()
        {
            InitializeComponent();
            _viewModel = new ComicPageViewModel();
            _viewModel.Navigation = Navigation;
            BindingContext = _viewModel;
        }
    }
}