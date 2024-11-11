using System.Windows.Media;

namespace AKG1.Logic;

public static class ColorIntensityExtension
{
	public static Color SetIntensity(this Color color, float intensity)
	{
		intensity = Math.Clamp(intensity, 0, 1);

		byte newR = (byte)(color.R * intensity);
		byte newG = (byte)(color.G * intensity);
		byte newB = (byte)(color.B * intensity);

		var alpha = (byte)(255 * intensity);

		return Color.FromArgb(alpha, newR, newG, newB);
	}
}
