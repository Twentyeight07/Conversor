using Conversor.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        private void CalculateBs()
		{
			dolar = Convert.ToDouble(txtDs.Text);
			res = dolar * bs;
			lblResult.Text = "Bs./ " + res.ToString("N", new CultureInfo("es-Ve"));
		}

        private void CalculateDs()
        {
            dolar = Convert.ToDouble(txtDs.Text);
            res = dolar / bs;
            lblResult.Text = "$./ " + res.ToString("N", new CultureInfo("es-Us"));
        }

        private void Validate()
		{
			if(!string.IsNullOrEmpty(txtDs.Text))
			{
				if(txtDs.Placeholder == "Dólares / $")
				{
                    CalculateBs();
				}
				else
				{
					CalculateDs();
				}
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

        private void btnChangeCurrency_Clicked(object sender, EventArgs e)
        {
			if(txtDs.Placeholder == "Dólares / $")
			{
				imgFrom.Source = "bolivar.png";
				imgTo.Source = "dollar.png";
				txtDs.Placeholder = "Bolívares / Bs";
				txtDs.Text = "";
				lblResult.Text = "";
			}
			else
			{
                imgFrom.Source = "dollar.png";
                imgTo.Source = "bolivar.png";
                txtDs.Placeholder = "Dólares / $";
				txtDs.Text = "";
				lblResult.Text = "";
            }
        }

        private void txtDs_TextChanged(object sender, TextChangedEventArgs e)
        {
			
			if(!string.IsNullOrEmpty(e.NewTextValue))
			{
				// Remove any format
				string formattedText = e.NewTextValue.Replace(".", "");

				if(double.TryParse(formattedText, out double number))
				{
					// Apply new format
					formattedText = number.ToString("N", new CultureInfo("es-Ve"));
				}

				txtDs.Text = formattedText;
			}
        }
    }
}