using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Circle;

public static class BresenhamHyperbola
{
	public static async Task DrawHyperbola(this WriteableBitmap bitmap, int a, int b, Point point, Color color, bool isDebug = false)
	{
		// Начальные координаты
		int x = a;
		int y = 0;

		// Начальное значение дельта
		int delta = b * b - 2 * a * a * b;

		while (x >= 0)
		{
			// Выводим пиксели для текущих координат с учетом начальной точки
			PutPixel(bitmap, (int)point.X + x, (int)point.Y + y, color);
			PutPixel(bitmap, (int)point.X + x, (int)point.Y - y, color);
			PutPixel(bitmap, (int)point.X - x, (int)point.Y + y, color);
			PutPixel(bitmap, (int)point.X - x, (int)point.Y - y, color);

			if (delta > 0)
			{
				// Сдвигаем y на 1 вверх, если delta > 0
				y += 1;
				delta -= 2 * b * b * y + b * b;
			}
			// Сдвигаем x на 1 влево
			x -= 1;
			delta += 2 * a * a * x + a * a;

			if (isDebug)
				await Task.Delay(45);
		}
	}

	private static void PutPixel(WriteableBitmap bitmap, int x, int y, Color color)
	{
		bitmap.SetPixel(x, y, color);
	}
}
