using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xkcd_comics.Services;
using xkcd_comics.Views;

namespace xkcd_comics
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DataService>();
            MainPage = new MainPage();
        }
        public App(string filePath)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DataService>();
            MainPage = new MainPage();

            FilePath = filePath;
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
