using AKG1.Logic.Interfaces;
using AKG1.Models;
using System.Windows;

namespace AKG1.Logic.Implementation
{
	public class DdaBuilder : ILineBuilder
	{
		public Line2D Build(Point point1, Point point2)
		{
			List<Point> points = new List<Point>();

			int dx = (int)(point2.X - point1.X);
			int dy = (int)(point2.Y - point1.Y);
			int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

			float xIncrement = dx / (float)steps;
			float yIncrement = dy / (float)steps;

			double x = point1.X;
			double y = point1.Y;

			for (int i = 0; i <= steps; i++)
			{
				points.Add(new Point(x, y));
				//bitmap.SetPixel((int)Math.Round(x), (int)Math.Round(y), color);
				x += xIncrement;
				y += yIncrement;
			}

			var line = new Line2D(point1, point2, points.ToArray());

			return line;
		}
	}
}
