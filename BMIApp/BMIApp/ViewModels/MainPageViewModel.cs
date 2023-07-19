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
				Result = User.Weight / (User.Height * User.Height);
			});
		}
	}
}
