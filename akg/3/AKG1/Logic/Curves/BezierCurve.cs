using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Curves;

public static class BezierCurve
{
	// Метод для вычисления точки на кривой Безье
	private static Point ComputeBezierPoint(double t, Point[] points)
	{
		int n = points.Length - 1;
		Point[] temp = new Point[n + 1];
		Array.Copy(points, temp, n + 1);

		for (int r = 1; r <= n; r++)
		{
			for (int i = 0; i <= n - r; i++)
			{
				temp[i].X = (1 - t) * temp[i].X + t * temp[i + 1].X;
				temp[i].Y = (1 - t) * temp[i].Y + t * temp[i + 1].Y;
			}
		}

		return temp[0];
	}

	public static void DrawBezierCurve(this WriteableBitmap bitmap, Point[] points, Color color, bool isDebug = false)
	{
		for (double t = 0; t <= 1; t += 0.0015)
		{
			Point point = ComputeBezierPoint(t, points);
			// Установите пиксель в координатах point.X и point.Y
			bitmap.SetPixel((int)point.X, (int)point.Y, color);
			//SetPixel((int)point.X, (int)point.Y);
		}
	}
}
