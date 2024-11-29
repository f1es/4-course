using AKG1.Logic.Implementation;
using AKG1.Logic.Interfaces;
using System.Net;
using System.Windows;

namespace AKG1.Models;

public class Square
{
	private Point[] _points;
    private Line2D[] _lines;

    public Square(Point firstPoint, Point secondPoint)
    {
        var thirdPoint = new Point(firstPoint.X, secondPoint.Y);
        var fourthPoint = new Point(secondPoint.X, firstPoint.Y);
        _points = [firstPoint, thirdPoint, secondPoint, fourthPoint];


	    ILineBuilder lineBuilder = new DdaBuilder();
        var lines = new List<Line2D>();

        for (int i = 1; i < _points.Length; i++)
        {
            var startPoint = _points[i - 1];
            var endPoint = _points[i];
            var line = lineBuilder.Build(startPoint, endPoint);
            lines.Add(line);
		}

        var fourthLine = lineBuilder.Build(_points.First(), _points.Last());
        lines.Add(fourthLine);

		_lines = lines.ToArray();
	}

    public Point[] Points => _points;
    public Line2D[] Lines => _lines;

	public bool IsPointInside(Point point)
	{
		var x = point.X;
		var y = point.Y;

		var minX = _points.Min(p => p.X);
		var maxX = _points.Max(p => p.X);
		var minY = _points.Min(p => p.Y);
		var maxY = _points.Max(p => p.Y);

		return x >= minX && x <= maxX && y >= minY && y <= maxY;
	}

	public bool IsLineOutside(Line2D line)
	{
		foreach(var point in line.Points)
		{
			if (IsPointInside(point))
				return false;
		}

		return true;
	}
}
