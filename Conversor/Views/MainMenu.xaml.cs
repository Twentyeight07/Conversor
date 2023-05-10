using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Conversor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            DisplayAlert("Información", "Para utilizar esta aplicación se debe tener conexión a internet", "Ok");

            InitializeComponent();
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Converting());
        }
    }
}