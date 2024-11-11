using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Curves;

public static class BSplineCurve
{
	// Метод для вычисления точки на B-сплайне
	private static Point ComputeBSplinePoint(double t, Point[] controlPoints, int degree, double[] knots)
	{
		int n = controlPoints.Length - 1;
		int k = FindKnotInterval(t, degree, knots);

		double x = 0;
		double y = 0;

		for (int i = 0; i <= degree; i++)
		{
			double b = BasisFunction(i, degree, t, knots, k);
			x += b * controlPoints[k - degree + i].X;
			y += b * controlPoints[k - degree + i].Y;
		}

		return new Point(x, y);
	}

	// Метод для нахождения узлового интервала
	private static int FindKnotInterval(double t, int degree, double[] knots)
	{
		for (int i = degree; i < knots.Length - degree - 1; i++)
		{
			if (t >= knots[i] && t < knots[i + 1])
				return i;
		}
		return knots.Length - degree - 2;
	}

	// Метод для вычисления базисной функции
	private static double BasisFunction(int i, int degree, double t, double[] knots, int k)
	{
		if (degree == 0)
		{
			if (knots[i] <= t && t < knots[i + 1])
				return 1.0;
			return 0.0;
		}
		else
		{
			double left = 0.0;
			double right = 0.0;

			if (knots[i + degree] != knots[i])
				left = (t - knots[i]) / (knots[i + degree] - knots[i]) * BasisFunction(i, degree - 1, t, knots, k);

			if (knots[i + degree + 1] != knots[i + 1])
				right = (knots[i + degree + 1] - t) / (knots[i + degree + 1] - knots[i + 1]) * BasisFunction(i + 1, degree - 1, t, knots, k);

			return left + right;
		}
	}

	public static void DrawBSplineCurve(this WriteableBitmap bitmap, Point[] points, int degree, Color color, bool isDebug = false)
	{
		double[] knots = { 1, 1, 1, 2, 2, 3, 4, 5 };

		// Вычисление точек B-сплайна
		for (double t = 0; t <= 4; t += 0.0015)
		{
			Point point = ComputeBSplinePoint(t, points, degree, knots);
			// Установите пиксель в координатах point.X и point.Y
			//SetPixel((int)point.X, (int)point.Y);
			bitmap.SetPixel((int)point.X, (int)point.Y, color);
		}
	}
}
