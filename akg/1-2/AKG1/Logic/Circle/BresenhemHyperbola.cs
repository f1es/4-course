using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Circle;

public static class BresenhamHyperbola
{
	public static async Task DrawHyperbolaBresenhem(this WriteableBitmap bitmap, int a, int b, Point point, Color color, bool isDebug = false)
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

	public static async Task DrawHyperbola(this WriteableBitmap bitmap, Point point, int scale, Color color, bool isDebug = false)
	{
		//int centerX = 40; // Центр гиперболы по X (можете изменить)
		//int centerY = 12; // Центр гиперболы по Y (можете изменить)
		//int scale = 10;   // Масштаб (чтобы гипербола была видна)

		for (float x = -20; x <= 20; x += 0.01f)
		{
			float y = (float)Math.Sqrt(x * x + 1);

			var calcX = (int)point.X + (int)(x * scale);
			var calcYminus = (int)point.Y - (int)(y * scale);
			var calcYplus = (int)point.Y + (int)(y * scale);

			PutPixel(bitmap, calcX, calcYminus, color);
			PutPixel(bitmap, calcX, calcYplus, color);

			if (isDebug)
				await Task.Delay(15);
		}
	}
}
