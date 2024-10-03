using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AKG1.Logic.Line;

public static class WuAlgorithm
{
	public static void DrawWuLine(this WriteableBitmap bitmap, Point point0, Point point1, Color color)
	{
		int x0 = (int)point0.X;
		int y0 = (int)point0.Y;
		int x1 = (int)point1.X;
		int y1 = (int)point1.Y;

		bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
		if (steep)
		{
			Swap(ref x0, ref y0);
			Swap(ref x1, ref y1);
		}
		if (x0 > x1)
		{
			Swap(ref x0, ref x1);
			Swap(ref y0, ref y1);
		}

		int dx = x1 - x0;
		int dy = y1 - y0;
		float gradient = dy / (float)dx;

		// Handle first endpoint
		float xEnd = Round(x0);
		float yEnd = y0 + gradient * (xEnd - x0);
		float xGap = Rfpart(x0 + 0.5f);
		int xPixel1 = (int)xEnd;
		int yPixel1 = (int)yEnd;

		if (steep)
		{
			bitmap.SetPixel(yPixel1, xPixel1, color.SetIntensity(Rfpart(yEnd) * xGap));
			bitmap.SetPixel(yPixel1 + 1, xPixel1, color.SetIntensity(Fpart(yEnd) * xGap));
		}
		else
		{
			bitmap.SetPixel(xPixel1, yPixel1, color.SetIntensity(Rfpart(yEnd) * xGap));
			bitmap.SetPixel(xPixel1, yPixel1 + 1, color.SetIntensity(Fpart(yEnd) * xGap));
		}

		float intery = yEnd + gradient;

		// Handle second endpoint
		xEnd = Round(x1);
		yEnd = y1 + gradient * (xEnd - x1);
		xGap = Fpart(x1 + 0.5f);
		int xPixel2 = (int)xEnd;
		int yPixel2 = (int)yEnd;

		if (steep)
		{
			bitmap.SetPixel(yPixel2, xPixel2, color.SetIntensity(Rfpart(yEnd) * xGap));
			bitmap.SetPixel(yPixel2 + 1, xPixel2, color.SetIntensity(Fpart(yEnd) * xGap));
		}
		else
		{
			bitmap.SetPixel(xPixel2, yPixel2, color.SetIntensity(Rfpart(yEnd) * xGap));
			bitmap.SetPixel(xPixel2, yPixel2 + 1, color.SetIntensity(Fpart(yEnd) * xGap));
		}

		// Main loop
		for (int x = xPixel1 + 1; x < xPixel2; x++)
		{
			if (steep)
			{
				bitmap.SetPixel((int)intery, x, color.SetIntensity(Rfpart(intery)));
				bitmap.SetPixel((int)intery + 1, x, color.SetIntensity(Fpart(intery)));
			}
			else
			{
				bitmap.SetPixel(x, (int)intery, color.SetIntensity(Rfpart(intery)));
				bitmap.SetPixel(x, (int)intery + 1, color.SetIntensity(Fpart(intery)));
			}

			intery += gradient;
		}
	}

	private static void Swap(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}

	private static float Round(float x) =>
		(float)Math.Floor(x + 0.5f);

	private static float Fpart(float x) =>
		x - (float)Math.Floor(x);

	private static float Rfpart(float x) =>
		1 - Fpart(x);
}
