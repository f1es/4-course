using AKG1.Enum;
using AKG1.Logic;
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
		Image.MouseLeftButtonDown += ImageMouseLeftButtonDown;
		bitmap.SetPixel(5,5, Colors.Black.SetIntensity(0.1f));
	}
	private void InitializeBitmap()
	{
		bitmap = new WriteableBitmap((int)Image.Width, (int)Image.Height, 96, 96, PixelFormats.Bgra32, null);
		Image.Source = bitmap;
	}

	private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		Point position = e.GetPosition(Image);
		int x = (int)position.X;
		int y = (int)position.Y;

		if (firstPoint is null)
		{
			firstPoint = new Point(x, y);
		}
		else if (secondPoint is null) 
		{
			secondPoint = new Point(x, y);

			var selector = GetLineAlghoritmType();
			switch (selector)
			{
				case LineAlghoritmType.DDA:
					bitmap.DrawLineDDA((Point)firstPoint, (Point)secondPoint, Colors.Black);
					break;
				case LineAlghoritmType.Bresenhem:
					bitmap.DrawBresenhamLine((Point)firstPoint, (Point)secondPoint, Colors.Black);
					break;
				case LineAlghoritmType.Wu:
					bitmap.DrawWuLine((Point)firstPoint, (Point)secondPoint, Colors.Black);
					break;
			}

			
			firstPoint = null;
			secondPoint = null;
		}
	}

	private LineAlghoritmType GetLineAlghoritmType()
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
				return LineAlghoritmType.DDA;
			case "Брезенхем":
				return LineAlghoritmType.Bresenhem;
			case "Ву":
				return LineAlghoritmType.Wu;
		}

		return LineAlghoritmType.DDA;
	}

	private void ClearButtonClick(object sender, RoutedEventArgs e)
	{
		InitializeBitmap();
	}
}