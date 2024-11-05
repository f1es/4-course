using AKG1.Enum;
using AKG1.Logic;
using AKG1.Logic.Circle;
using AKG1.Logic.Curves;
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
	private List<Point> points = new List<Point>();
	public MainWindow()
	{
		InitializeComponent();
		InitializeBitmap();

		//bitmap.DrawHermitCurve();
		var points = new Point[]
		{
			new Point(50, 200),
			new Point(150, 50),
			new Point(250, 350),
			new Point(350, 200),
			new Point(450, 50)
		};
		bitmap.DrawBSplineCurve(points, 3, Colors.Red);
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

		var selector = GetAlghoritmType();

		switch (selector)
		{
			case AlghoritmType.Hermit:
				points.Add(position);

				if (points.Count == 4)
				{
					var p0 = points[0];
					var m0 = points[1];
					var m1 = points[2];
					var p1 = points[3];

					bitmap.DrawHermitCurve(p0, p1, m0, m1, Colors.Red);
					points.Clear();
				}
				break;

			case AlghoritmType.Bezier:
				points.Add(position);

				if (points.Count >= 4)
				{
					bitmap.DrawBezierCurve(points.ToArray(), Colors.Red);
					points.Clear();
				}

				break;
			case AlghoritmType.BSpline:
				points.Add(position);

				if  (points.Count >= 5)
				{
					bitmap.DrawBSplineCurve(points.ToArray(), 3, Colors.Red);
					points.Clear();
				}
				break;
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
			case "Эрмит":
				return AlghoritmType.Hermit;
			case "Безье":
				return AlghoritmType.Bezier;
			case "В-Сплайн":
				return AlghoritmType.BSpline;
			//case "ЦДА":
			//	return AlghoritmType.DDA;
			//case "Брезенхем":
			//	return AlghoritmType.Bresenhem;
			//case "Ву":
			//	return AlghoritmType.Wu;
			//case "Окружность Брезенхем":
			//	return AlghoritmType.BresenhemCircle;
			//case "Элипс Брезенхем":
			//	return AlghoritmType.BresenhemEllipse;
			//case "Гипербола":
			//	return AlghoritmType.Hyperbola;
			//case "Парабола":
			//	return AlghoritmType.Parabola;
		}

		return AlghoritmType.DDA;
	}

	private void ClearButtonClick(object sender, RoutedEventArgs e)
	{
		InitializeBitmap();
	}
}