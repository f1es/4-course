using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Line;

public static class BresenhemAlgorithm
{
	public static void DrawBresenhamLine(this WriteableBitmap bitmap, int x0, int y0, int x1, int y1, Color color)
	{
		int dx = Math.Abs(x1 - x0);
		int dy = Math.Abs(y1 - y0);
		int sx = x0 < x1 ? 1 : -1;
		int sy = y0 < y1 ? 1 : -1;
		int err = dx - dy;

		while (true)
		{
			bitmap.SetPixel(x0, y0, color);

			if (x0 == x1 && y0 == y1) 
				break;
			int e2 = 2 * err;
			if (e2 > -dy)
			{
				err -= dy;
				x0 += sx;
			}
			if (e2 < dx)
			{
				err += dx;
				y0 += sy;
			}
		}
	}

	public static async Task DrawBresenhamLine(this WriteableBitmap bitmap, Point point0, Point point1, Color color, bool isDebug = false)
	{
		int x0 = (int)point0.X;
		int y0 = (int)point0.Y;
		int x1 = (int)point1.X;
		int y1 = (int)point1.Y;

		int dx = Math.Abs(x1 - x0);
		int dy = Math.Abs(y1 - y0);
		int sx = x0 < x1 ? 1 : -1;
		int sy = y0 < y1 ? 1 : -1;
		int err = dx - dy;

		while (true)
		{
			if (isDebug)
				await Task.Delay(100);

			bitmap.SetPixel(x0, y0, color);

			if (x0 == x1 && y0 == y1)
				break;

			int e2 = 2 * err;
			if (e2 > -dy)
			{
				err -= dy;
				x0 += sx;
			}
			if (e2 < dx)
			{
				err += dx;
				y0 += sy;
			}
		}
	}
}
