using AKG1.Logic.Interfaces;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AKG1.Models;

public class Line2D
{
	private Point _first;
	private Point _last;
	private Point[] _points;

	public Line2D(Point first, Point last, Point[] points)
	{
		_first = first;
		_last = last;
		_points = points;
	}

	public Point First => _first;
	public Point Last => _last;
	public Point[] Points => _points;
}
