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
    public partial class FavoritesPage : ContentPage
    {
        FavoritesPageViewModel _viewModel;
        public FavoritesPage()
        {
            InitializeComponent();
            _viewModel = new FavoritesPageViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            _viewModel.FavList.Clear();
            _viewModel.GetComicsFromDb();
        }

        private void FavListTapped_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }
}