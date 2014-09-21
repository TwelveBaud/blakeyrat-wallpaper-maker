using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public partial class DoubleColor
	{
		public double R { get; set; }
		public double G { get; set; }
		public double B { get; set; }
		public double A { get; set; }

		public DoubleColor()
		{
			R = 0.0;
			G = 0.0;
			B = 0.0;
			A = 1.0;
		}

		public DoubleColor(double rIn, double gIn, double bIn)
		{
			R = rIn;
			G = gIn;
			B = bIn;
			A = 1.0;
		}

		public DoubleColor(double rIn, double gIn, double bIn, double aIn)
		{
			R = rIn;
			G = gIn;
			B = bIn;
			A = aIn;
		}

		public void RandomizeAlpha()
		{
			A = RandomNumberProvider.GetDouble();
		}

		public void NormalizeRGB()
		{
			double maxVal = Math.Max(Math.Max(R, G), B);

			if (maxVal <= 1.0)
			{
				return;
			}

			double correction = 1.0 / maxVal;

			R = R * correction;
			G = G * correction;
			B = B * correction;
		}

		public Color ToColor()
		{
			NormalizeRGB();

			int intA = Convert.ToInt32(A * 255.0);
			int intR = Convert.ToInt32(R * 255.0);
			int intG = Convert.ToInt32(G * 255.0);
			int intB = Convert.ToInt32(B * 255.0);

			return Color.FromArgb(intA, intR, intG, intB);
		}
	}
}
