using BMIApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BMIApp.ViewModels
{
	public class MainPageViewModel: INotifyPropertyChanged
	{
		private double result = 0;

		#region OnPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
		}
		#endregion

		public ICommand CalculateBMI { get; set; }
        public BMI User { get; set; }
		public double Result
		{
			get => result;
			set
			{
				result = value;
				OnPropertyChanged();
			}
		}

		public MainPageViewModel()
        {
			User = new BMI
			{
				Height = 0,
				Weight = 0
			};

			CalculateBMI = new Command(() =>
			{
				if(User.Height == 0 || User.Weight == 0)
				{
					Application.Current.MainPage.DisplayAlert("Error", "Please, fill in the form", "Ok");
					return;
				}
				Result = User.Weight / (User.Height * User.Height);
				Application.Current.MainPage.DisplayAlert("BMI Result", this.GetBMIMessage(Result), "Ok");
			});
		}

		private string GetBMIMessage(double BMIResult)
		{
			string message = "";
			switch (BMIResult)
			{
				case double result when result < 18.5:
					message = "Your weight is low";
					break;

				case double result when result <= 24.9:
					message = "You weight is normal";
					break;

				case double result when result <= 29.9:
					message = "You have overweight";
					break;

				default:
					message = "You are obese";
					break;
			}

			return message;
		}
	}
}
