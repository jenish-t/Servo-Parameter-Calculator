using System;
using System.Windows;

namespace ServoParaCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public float PitchVar { get; set; }
		public float GearBoxVar { get; set; }
		public float RatedSpeed { get; set; }
		public float Numerator { get; set; }
		public float ReferanceVelocity { get; set; }
		public float MaxVelocity { get; set; }
		public float Factor { get; set; }
		public MainWindow()
		{
			InitializeComponent();

			var timer = new System.Windows.Threading.DispatcherTimer();
			timer.Tick += (sender, e) =>
			{
				if (float.TryParse(pitchHMI.Text, out float parsedFloat))
				{
					PitchVar = parsedFloat;
				}
				else
				{
					PitchVar = 1;
					//MessageBox.Show("Invalid input. Please enter a valid float number.");
				}

				if (float.TryParse(RPMHMI.Text, out float parsedFloat1))
				{
					RatedSpeed = parsedFloat1;
				}
				else
				{
					RatedSpeed = 3000;
					//MessageBox.Show("Invalid input. Please enter a valid float number.");
				}

				if (float.TryParse(GearHMI.Text, out float parsedFloat2))
				{
					GearBoxVar = parsedFloat2;
				}
				else
				{
					GearBoxVar = 1;
					//MessageBox.Show("Invalid input. Please enter a valid float number.");
				}

				if (GearBoxVar > 0)//numerator value display
				{
					Numerator = (PitchVar / GearBoxVar);
					num_display.Text = ($"{Numerator}");
				}

				ReferanceVelocity = (RatedSpeed / 60) * Numerator;
				RefVelocityDisp.Text = ($"{ReferanceVelocity}");

				Factor = 95;
				MaxVelocity = ReferanceVelocity * (Factor / 100);
				MaxVelocityDisp.Text = ($"{MaxVelocity}");
			};
			timer.Interval = TimeSpan.FromMilliseconds(100);
			timer.Start();

		}
	}
}
