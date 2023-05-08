using Conversor.Global;
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
	public partial class Converting : ContentPage
	{
        public Converting ()
		{
            InitializeComponent ();
		}

        double bs = ExchangeRate.Rate;
        double dolar;
        double res;


        private void Calculate()
		{
			dolar = Convert.ToDouble(txtDs.Text);
			res = dolar * bs;
			lblResult.Text = "Bs " + res;
		}

		private void Validate()
		{
			if(!string.IsNullOrEmpty(txtDs.Text))
			{
				Calculate();
			}
			else
			{
				DisplayAlert("Error!","Necesitas introducir una cantidad a convertir","Ok");
			}
		}

        private void btnBack_Clicked(object sender, EventArgs e)
        {
			Navigation.PopAsync();
        }

        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
			Validate();
        }
    }
}