namespace AKG1.Logic.Circle;

using AKG1.Logic.Line;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class Parabola
{
	public static async Task DrawParabola(this WriteableBitmap bitmap, Point point, int range, Color color, bool isDebug = false)
	{
		var x = range;
		var y = x * x;
		var firstPoint = new Point(point.X - x, point.Y - y);

		// Пробегаем по значениям x от -range до range
		for (x = -range; x <= range; x++)
		{
			// Вычисляем значение y для параболы y = x^2
			y = x * x;
			var secondPoint = new Point(point.X + x, point.Y - y);
			await bitmap.DrawBresenhamLine(firstPoint, secondPoint, color, isDebug);
			firstPoint = secondPoint;
		}
	}
}
