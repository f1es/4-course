using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace AKG1.Logic;

public static class PixelBrush
{
	public static void SetPixel(this WriteableBitmap bitmap, int x, int y, Color color)
	{
		bool isPointHasNegativeValue = x < 0 || y < 0;
		bool isPointBiggerThanBitmap = x >= bitmap.PixelWidth || y >= bitmap.PixelHeight;

		if (isPointHasNegativeValue || isPointBiggerThanBitmap)
			return;

		try
		{
			bitmap.Lock();
			byte[] colorData = { color.B, color.G, color.R, color.A };
			Int32Rect rect = new Int32Rect(x, y, 1, 1);
			bitmap.AddDirtyRect(rect);
			bitmap.WritePixels(rect, colorData, 4, 0);
			bitmap.Unlock();
		}
		catch
		{

		}
	}
}
