using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace AKG1.Logic;

public static class PixelBrush
{
	public static void SetPixel(this WriteableBitmap bitmap, int x, int y, Color color)
	{
		try
		{
			byte[] colorData = { color.B, color.G, color.R, color.A };
			Int32Rect rect = new Int32Rect(x, y, 1, 1);
			bitmap.WritePixels(rect, colorData, 4, 0);
		}
		catch
		{

		}
	}
}
