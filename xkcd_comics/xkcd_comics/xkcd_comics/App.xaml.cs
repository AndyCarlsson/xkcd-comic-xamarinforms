using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using xkcd_comics.Services;
using xkcd_comics.ViewModels;
using xkcd_comics.Views;

namespace xkcd_comics
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataService>();
            MainPage = new MainPage();
        }
        public App(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;

            DependencyService.Register<DataService>();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
