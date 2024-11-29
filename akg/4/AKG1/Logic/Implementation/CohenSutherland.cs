using AKG1.Logic.Interfaces;
using AKG1.Models;
using System.Windows;

namespace AKG1.Logic.Implementation;

public class CohenSutherlandClipper
{
	private readonly ILineBuilder _lineBuilder;

    public CohenSutherlandClipper(ILineBuilder lineBuilder)
    {
        _lineBuilder = lineBuilder;
    }

    // Константы кода отсечения
    const int INSIDE = 0; // 0000
	const int LEFT = 1;   // 0001
	const int RIGHT = 2;  // 0010
	const int BOTTOM = 4; // 0100
	const int TOP = 8;    // 1000

	private int ComputeOutCode(double x, double y, double xMin, double xMax, double yMin, double yMax)
	{
		int code = INSIDE;

		if (x < xMin)
			code |= LEFT;
		else if (x > xMax)
			code |= RIGHT;
		if (y < yMin)
			code |= BOTTOM;
		else if (y > yMax)
			code |= TOP;

		return code;
	}

	public Line2D CohenSutherlandClip(Line2D line, double xMin, double xMax, double yMin, double yMax) =>
		CohenSutherlandClip(line.First, line.Last, xMin, xMax, yMin, yMax);
	public Line2D CohenSutherlandClip(Point firstPoint, Point secondPoint, double xMin, double xMax, double yMin, double yMax) =>
		CohenSutherlandClip(firstPoint.X, firstPoint.Y, secondPoint.X, secondPoint.Y, xMin, xMax, yMin, yMax);
	public Line2D CohenSutherlandClip(double x0, double y0, double x1, double y1, double xMin, double xMax, double yMin, double yMax)
	{
		int outCode0 = ComputeOutCode(x0, y0, xMin, xMax, yMin, yMax);
		int outCode1 = ComputeOutCode(x1, y1, xMin, xMax, yMin, yMax);

		bool accept = false;

		while (true)
		{
			if ((outCode0 | outCode1) == 0)
			{
				accept = true;

				var firstPoint = new Point(x0, y0);
				var secondPoint = new Point(x1, y1);
				var line = _lineBuilder.Build(firstPoint, secondPoint);
				return line;

				//break;
			}
			else if ((outCode0 & outCode1) != 0)
			{
				var firstPoint = new Point(x0, y0);
				var secondPoint = new Point(x1, y1);
				var line = _lineBuilder.Build(firstPoint, secondPoint);
				return line;

				//break;
			}
			else
			{
				double x, y;
				int outCodeOut = (outCode0 != 0) ? outCode0 : outCode1;

				if ((outCodeOut & TOP) != 0)
				{
					x = x0 + (x1 - x0) * (yMax - y0) / (y1 - y0);
					y = yMax;
				}
				else if ((outCodeOut & BOTTOM) != 0)
				{
					x = x0 + (x1 - x0) * (yMin - y0) / (y1 - y0);
					y = yMin;
				}
				else if ((outCodeOut & RIGHT) != 0)
				{
					y = y0 + (y1 - y0) * (xMax - x0) / (x1 - x0);
					x = xMax;
				}
				else
				{
					y = y0 + (y1 - y0) * (xMin - x0) / (x1 - x0);
					x = xMin;
				}

				if (outCodeOut == outCode0)
				{
					x0 = x;
					y0 = y;
					outCode0 = ComputeOutCode(x0, y0, xMin, xMax, yMin, yMax);
				}
				else
				{
					x1 = x;
					y1 = y;
					outCode1 = ComputeOutCode(x1, y1, xMin, xMax, yMin, yMax);
				}
			}
		}
	}
}

