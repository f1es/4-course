using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Circle;

public static class BresenhemCircle
{
	public static async Task DrawCircleBresenham(this WriteableBitmap bitmap, Point point, int radius, Color color, bool isDebug = false)
	{
		int xc = (int)point.X;
		int yc = (int)point.Y;

		int x = 0;
		int y = radius;
		int d = 3 - 2 * radius;

		DrawCirclePoints(bitmap, xc, yc, x, y, color);

		while (y >= x)
		{
			x++;

			// Проверка принятия решения
			if (d > 0)
			{
				y--;
				d = d + 4 * (x - y) + 10;
			}
			else
			{
				d = d + 4 * x + 6;
			}

			DrawCirclePoints(bitmap, xc, yc, x, y, color);

			if (isDebug)
				await Task.Delay(75);
		}
	}

	public static void DrawCirclePoints(WriteableBitmap bitmap, int xc, int yc, int x, int y, Color color)
	{
		// Рисуем пиксели для каждой симметричной точки окружности
		bitmap.SetPixel(xc + x, yc + y, color);
		bitmap.SetPixel(xc - x, yc + y, color);
		bitmap.SetPixel(xc + x, yc - y, color);
		bitmap.SetPixel(xc - x, yc - y, color);
		bitmap.SetPixel(xc + y, yc + x, color);
		bitmap.SetPixel(xc - y, yc + x, color);
		bitmap.SetPixel(xc + y, yc - x, color);
		bitmap.SetPixel(xc - y, yc - x, color);

		
		//PutPixel(xc + x, yc + y); // Пиксель 1
		//PutPixel(xc - x, yc + y); // Пиксель 2
		//PutPixel(xc + x, yc - y); // Пиксель 3
		//PutPixel(xc - x, yc - y); // Пиксель 4
		//PutPixel(xc + y, yc + x); // Пиксель 5
		//PutPixel(xc - y, yc + x); // Пиксель 6
		//PutPixel(xc + y, yc - x); // Пиксель 7
		//PutPixel(xc - y, yc - x); // Пиксель 8
	}
}
