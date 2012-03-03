using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	static class ColorUtils
	{
		static public Color GetRandomColor()
		{
			//double odds = RandomNumberProvider.GetRandDouble();

			//if (odds < 0.25)
			//{
			//    if (odds < (0.25 * 0.25))
			//    {
			//        if (RandomNumberProvider.GetRandDouble() < 0.5)
			//        {
			//            return (Color.White);
			//        }
			//        else
			//        {
			//            return (Color.Black);
			//        }
			//    }
			//    int value = RandomNumberProvider.GetRandInt(256);
			//    return (Color.FromArgb(value, value, value));
			//}

			return (Color.FromArgb(RandomNumberProvider.GetRandInt(256), RandomNumberProvider.GetRandInt(256), RandomNumberProvider.GetRandInt(256)));
		}

		static public int GetRandomAlpha()
		{
			return (RandomNumberProvider.GetRandInt(127));
		}

		static public Color Combine(Color colorA, Color colorB)
		{
			if (colorA.A == 0)
			{
				return colorB;
			}
			if (colorB.A == 0)
			{
				return colorA;
			}

			double totalAlpha = Convert.ToDouble(colorA.A) + Convert.ToDouble(colorB.A);
			double aWeight = (Convert.ToDouble(colorA.A) / totalAlpha);
			double bWeight = (Convert.ToDouble(colorB.A) / totalAlpha);

			int a = Convert.ToInt32(totalAlpha / 2);
			int r = Convert.ToInt32(Convert.ToDouble(colorA.R) * aWeight + Convert.ToDouble(colorB.R) * bWeight);
			int g = Convert.ToInt32(Convert.ToDouble(colorA.G) * aWeight + Convert.ToDouble(colorB.G) * bWeight);
			int b = Convert.ToInt32(Convert.ToDouble(colorA.B) * aWeight + Convert.ToDouble(colorB.B) * bWeight);

			return Color.FromArgb(a, r, g, b);
		}

		static public Color CapColor(int a, int r, int g, int b)
		{
			double highest = Math.Max(Math.Max(r, g), b);

			if (highest > 0)
			{
				r = Convert.ToInt32((Convert.ToDouble(r) / highest) * 255);
				g = Convert.ToInt32((Convert.ToDouble(g) / highest) * 255);
				b = Convert.ToInt32((Convert.ToDouble(b) / highest) * 255);
			}

			return Color.FromArgb(a, r, g, b);
		}
	}
}
