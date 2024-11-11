using AKG1.Enum;
using AKG1.Logic;
using AKG1.Logic.Circle;
using AKG1.Logic.Line;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private WriteableBitmap bitmap;
	private Point? firstPoint;
	private Point? secondPoint;
	public MainWindow()
	{
		InitializeComponent();
		InitializeBitmap();
	}
	private void InitializeBitmap()
	{
		bitmap = new WriteableBitmap((int)Image.Width, (int)Image.Height, 91, 91, PixelFormats.Bgra32, null);
		Image.Source = bitmap;
	}

	public async void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		Point position = e.GetPosition(Image);
		int x = (int)position.X;
		int y = (int)position.Y;

		if (firstPoint is null)
		{
			firstPoint = new Point(x, y);

			var selector = GetAlghoritmType();
			switch(selector)
			{
				case AlghoritmType.BresenhemCircle:
					var radius = 10;
					int.TryParse(CircleRadiusTextBox.Text, out radius);
					await bitmap.DrawCircleBresenham(firstPoint.Value, radius, Colors.Red, DebugCheckBox.IsChecked.Value);
					firstPoint = null;
					break;

				case AlghoritmType.BresenhemEllipse:
					var xr = 10;
					var yr = 5;

					int.TryParse(EllipseRadiusXTextBox.Text, out xr);
					int.TryParse(EllipseRadiusYTextBox.Text, out yr);

					await bitmap.DrawEllipseBresenham(firstPoint.Value, xr, yr, Colors.Red, DebugCheckBox.IsChecked.Value);
					firstPoint = null;
					break;

				case AlghoritmType.Hyperbola:

					var scale = 10;
					//var b = 15;
					int.TryParse(HyperbolaScale.Text, out scale);
					//int.TryParse(HyperbolaB.Text, out b);

					await bitmap.DrawHyperbola(firstPoint.Value, scale, Colors.Red, DebugCheckBox.IsChecked.Value);
					firstPoint = null;
					break;

				case AlghoritmType.Parabola:

					var range = 10;
					int.TryParse(ParabolaRange.Text, out range);

					await bitmap.DrawParabola(firstPoint.Value, range, Colors.Red, DebugCheckBox.IsChecked.Value);
					firstPoint = null;
					break;
			}
		}
		else if (secondPoint is null) 
		{
			secondPoint = new Point(x, y);

			var selector = GetAlghoritmType();
			switch (selector)
			{
				case AlghoritmType.DDA:
					await bitmap.DrawLineDDA((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
				case AlghoritmType.Bresenhem:
					await bitmap.DrawBresenhamLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
				case AlghoritmType.Wu:
					await bitmap.DrawWuLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
			}
			
			firstPoint = null;
			secondPoint = null;
		}

		//Image.InvalidateVisual();
	}

	private AlghoritmType GetAlghoritmType()
	{
		var checkedRadioButton = AlgorithmSelector
			.Children
			.OfType<RadioButton>()
			.Where(rb => rb.IsChecked.HasValue && rb.IsChecked.Value)
			.FirstOrDefault();

		var value = checkedRadioButton.Content;
		switch(value)
		{
			case "ЦДА":
				return AlghoritmType.DDA;
			case "Брезенхем":
				return AlghoritmType.Bresenhem;
			case "Ву":
				return AlghoritmType.Wu;
			case "Окружность Брезенхем":
				return AlghoritmType.BresenhemCircle;
			case "Элипс Брезенхем":
				return AlghoritmType.BresenhemEllipse;
			case "Гипербола":
				return AlghoritmType.Hyperbola;
			case "Парабола":
				return AlghoritmType.Parabola;
		}

		return AlghoritmType.DDA;
	}

	private void ClearButtonClick(object sender, RoutedEventArgs e)
	{
		InitializeBitmap();
	}
}