using System.Windows;
using AKG1.Models;

namespace AKG1.Logic.Interfaces;

public interface ILineBuilder
{
	Line2D Build(Point first, Point last); 
}
