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

		//bitmap.DrawLineDDA(new Point(0,1), new Point(5,40), Colors.Red, DebugCheckBox.IsChecked.Value);
		//bitmap.DrawBresenhamLine(new Point(5,1), new Point(10, 40), Colors.Red, DebugCheckBox.IsChecked.Value);
		//bitmap.DrawWuLine(new Point(10, 1), new Point(15, 40), Colors.Red, DebugCheckBox.IsChecked.Value);
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
		}
		else if (secondPoint is null) 
		{
			secondPoint = new Point(x, y);

			var selector = GetLineAlghoritmType();
			switch (selector)
			{
				case LineAlghoritmType.DDA:
					await bitmap.DrawLineDDA((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
				case LineAlghoritmType.Bresenhem:
					await bitmap.DrawBresenhamLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
				case LineAlghoritmType.Wu:
					await bitmap.DrawWuLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
			}
			
			firstPoint = null;
			secondPoint = null;
		}

		Image.InvalidateVisual();
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