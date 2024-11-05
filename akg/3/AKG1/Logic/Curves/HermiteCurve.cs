using AKG1.Logic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class HermiteCurve
{
	// Метод для вычисления точки на кривой Эрмита
	private static Point ComputeHermitePoint(WriteableBitmap bitmap, double t, Point p0, Point p1, Point m0, Point m1)
	{
		double h00 = 2 * t * t * t - 3 * t * t + 1;
		double h10 = t * t * t - 2 * t * t + t; 
		double h01 = -2 * t * t * t + 3 * t * t;
		double h11 = t * t * t - t * t;

		double x = h00 * p0.X + h10 * m0.X + h01 * p1.X + h11 * m1.X;
		double y = h00 * p0.Y + h10 * m0.Y + h01 * p1.Y + h11 * m1.Y;

		return new Point(x, y);
	}

	public static void DrawHermitCurve(this WriteableBitmap bitmap, Point p0, Point p1, Point m0, Point m1, Color color, bool isDebug = false)
	{

		for (double t = 0; t <= 1; t += 0.0015)
		{
			var point = ComputeHermitePoint(bitmap, t, p0, p1, m0, m1);
			bitmap.SetPixel((int)point.X, (int)point.Y, color);
		}
	}
}