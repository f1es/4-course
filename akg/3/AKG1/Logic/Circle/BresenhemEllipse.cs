using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Circle;

public static class BresenhemEllipse
{
	public static async Task DrawEllipseBresenham(this WriteableBitmap bitmap, Point point, int rx, int ry, Color color, bool isDebug = false)
	{
		int xc = (int)point.X;
		int yc = (int)point.Y;

		int x = 0;
		int y = ry;
		int rx2 = rx * rx;
		int ry2 = ry * ry;
		int tworx2 = 2 * rx2;
		int twory2 = 2 * ry2;
		int p;
		int px = 0;
		int py = tworx2 * y;

		// Рисуем первую часть эллипса
		DrawEllipsePoints(bitmap, xc, yc, x, y, color);

		// Первая часть
		p = (int)(ry2 - (rx2 * ry) + (0.25 * rx2));
		while (px < py)
		{
			x++;
			px += twory2;
			if (p < 0)
			{
				p += ry2 + px;
			}
			else
			{
				y--;
				py -= tworx2;
				p += ry2 + px - py;
			}
			DrawEllipsePoints(bitmap, xc, yc, x, y, color);

			if (isDebug)
				await Task.Delay(75);
		}

		// Вторая часть
		p = (int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
		while (y > 0)
		{
			y--;
			py -= tworx2;
			if (p > 0)
			{
				p += rx2 - py;
			}
			else
			{
				x++;
				px += twory2;
				p += rx2 - py + px;
			}
			DrawEllipsePoints(bitmap, xc, yc, x, y, color);

			if (isDebug)
				await Task.Delay(75);
		}
	}

	private static void DrawEllipsePoints(WriteableBitmap bitmap, int xc, int yc, int x, int y, Color color)
	{
		// Рисуем пиксели для каждой симметричной точки эллипса
		PutPixel(bitmap, xc + x, yc + y, color); // Пиксель 1
		PutPixel(bitmap, xc - x, yc + y, color); // Пиксель 2
		PutPixel(bitmap, xc + x, yc - y, color); // Пиксель 3
		PutPixel(bitmap, xc - x, yc - y, color); // Пиксель 4
	}

	private static void PutPixel(WriteableBitmap bitmap, int x, int y, Color color)
	{
		bitmap.SetPixel(x, y, color);
	}
}
