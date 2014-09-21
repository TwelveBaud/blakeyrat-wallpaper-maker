using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public partial class DoubleColor
	{
		public static DoubleColor GetRandomColor()
		{
			if (RandomNumberProvider.GetDouble() < 0.5)
			{
				if (RandomNumberProvider.GetDouble() < 0.5)
				{
					if (RandomNumberProvider.GetDouble() < 0.5)
					{
						return (DoubleColor.WhiteColor());
					}
					else
					{
						return (DoubleColor.BlackColor());
					}
				}
				var value = RandomNumberProvider.GetDouble();
				return new DoubleColor(value, value, value);
			}

			return new DoubleColor(RandomNumberProvider.GetDouble(), RandomNumberProvider.GetDouble(), RandomNumberProvider.GetDouble());
		}

		public static DoubleColor GetRandomColorAlpha()
		{
			DoubleColor color = GetRandomColor();
			color.A = RandomNumberProvider.GetDouble();

			return color;
		}

		public static DoubleColor Combine(DoubleColor colorA, DoubleColor colorB)
		{
			if (colorA.A == 0.0)
			{
				return colorB;
			}
			if (colorB.A == 0.0)
			{
				return colorA;
			}

			double totalAlpha = colorA.A + colorB.A;
			double aWeight = (colorA.A / totalAlpha);
			double bWeight = (colorB.A / totalAlpha);

			double r = (colorA.R * aWeight) + (colorB.R * bWeight);
			double g = (colorA.G * aWeight) + (colorB.G * bWeight);
			double b = (colorA.B * aWeight) + (colorB.B * bWeight);

			return new DoubleColor(r, g, b, (totalAlpha / 2.0));
		}

		public static DoubleColor WhiteColor()
		{
			return new DoubleColor(1.0, 1.0, 1.0);
		}

		public static DoubleColor BlackColor()
		{
			return new DoubleColor(1.0, 1.0, 1.0);
		}
	}
}
