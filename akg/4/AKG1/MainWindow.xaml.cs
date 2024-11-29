using AKG1.Enum;
using AKG1.Logic;
using AKG1.Logic.Implementation;
using AKG1.Logic.Interfaces;
using AKG1.Logic.Line;
using AKG1.Models;
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

	private List<Line2D> lines = new List<Line2D>();
	private ILineBuilder builder = new DdaBuilder();
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
		}
		else if (secondPoint is null) 
		{
			secondPoint = new Point(x, y);

			var selector = GetAlghoritmType();
			switch (selector)
			{
				case AlghoritmType.DDA:
					
					var line = builder.Build(firstPoint.Value, secondPoint.Value);
					lines.Add(line);
					bitmap.Draw(line);

					break;

				case AlghoritmType.Bresenhem:
					await bitmap.DrawBresenhamLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;
				case AlghoritmType.Wu:
					await bitmap.DrawWuLine((Point)firstPoint, (Point)secondPoint, Colors.Red, DebugCheckBox.IsChecked.Value);
					break;

				case AlghoritmType.Border:

					CohenSutherlandClipper clipper = new CohenSutherlandClipper(builder);
					List<Line2D> newLines = new List<Line2D>();

					var xMin = Math.Min(firstPoint.Value.X, secondPoint.Value.X);
					var xMax = Math.Max(firstPoint.Value.X, secondPoint.Value.X);
					var yMin = Math.Min(firstPoint.Value.Y, secondPoint.Value.Y);
					var yMax = Math.Max(firstPoint.Value.Y, secondPoint.Value.Y);

					foreach(var line2d in lines)
					{
						var newLine = clipper.CohenSutherlandClip(line2d, xMin, xMax, yMin, yMax);

						var borderThirdPoint = new Point(firstPoint.Value.X, secondPoint.Value.Y);
						var borderFourthPoint = new Point(secondPoint.Value.X, firstPoint.Value.Y);

						newLines.Add(newLine);
					}

					InitializeBitmap();

					var square = new Square(firstPoint.Value, secondPoint.Value);
					bitmap.Draw(square);

					lines = newLines;

					var scopedLines = new List<Line2D>();

					foreach(var line2d in lines)
					{
						if (!square.IsLineOutside(line2d))
						{
							scopedLines.Add(line2d);
						}
					}

					lines = scopedLines;

					foreach(var line2d in lines)
					{
						bitmap.Draw(line2d);
					}

					break;
			}
			
			firstPoint = null;
			secondPoint = null;
		}

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

			case "Border":
				return AlghoritmType.Border;
		}

		return AlghoritmType.DDA;
	}

	private void ClearButtonClick(object sender, RoutedEventArgs e)
	{
		InitializeBitmap();
		lines.Clear();
	}
}