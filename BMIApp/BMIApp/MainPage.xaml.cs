using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMIApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			var height = double.Parse(Height.Text);
			var weight = double.Parse(Weight.Text);

			var bmi = weight / (height * height);

			BMI.Text = bmi.ToString();

			string result = "";

			if (bmi < 18.5)
			{
				result = "Your weight is low";
			}
			else if (bmi <= 24.9)
            {
				result = "You weight is normal";
            }
            else if (bmi <= 29.9)
            {
				result = "You have overweight";
			}
            else
            {
				result = "You are obese";
			}

			DisplayAlert("Message", result, "Ok");
        }
    }
}
