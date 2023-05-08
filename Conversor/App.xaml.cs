using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Conversor.Views;
using Conversor.Services;
using Conversor.Global;

namespace Conversor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            PerformWebScraping();

            MainPage = new NavigationPage(new MainMenu());

        }

        private async void PerformWebScraping()
        {
            try
            {
                var webScrapper = new WebScraper();
                string res = await webScrapper.ScrapeWebsite("https://www.bcv.org.ve");

                ExchangeRate.Rate = Convert.ToDouble(res);

            }
            catch (Exception ex)
            {
                // Manejo de errores
                await MainPage.DisplayAlert("Error al comunicarse con la web. Error: ", ex.Message, "OK");
            }
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
