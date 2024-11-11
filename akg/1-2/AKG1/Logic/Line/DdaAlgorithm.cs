using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Line;

public static class DdaAlgorithm
{
    public static void DrawLineDDA(this WriteableBitmap bitmap, int x1, int y1, int x2, int y2, Color color)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

        float xIncrement = dx / (float)steps;
        float yIncrement = dy / (float)steps;

        float x = x1;
        float y = y1;

        for (int i = 0; i <= steps; i++)
        {
            bitmap.SetPixel((int)Math.Round(x), (int)Math.Round(y), color);
            x += xIncrement;
            y += yIncrement;
        }
    }

    public static async Task DrawLineDDA(this WriteableBitmap bitmap, Point point1, Point point2, Color color, bool isDebug= false)
    {
        int dx = (int)(point2.X - point1.X);
        int dy = (int)(point2.Y - point1.Y);
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

        float xIncrement = dx / (float)steps;
        float yIncrement = dy / (float)steps;

        double x = point1.X;
        double y = point1.Y;

        for (int i = 0; i <= steps; i++)
        {
            if (isDebug)
                await Task.Delay(100);

            bitmap.SetPixel((int)Math.Round(x), (int)Math.Round(y), color);
            x += xIncrement;
            y += yIncrement;
        }
    }
}
