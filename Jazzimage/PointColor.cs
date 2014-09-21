using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	public class PointColor
	{
		public double X { get; set; }
		public double Y { get; set; }
		public DoubleColor Color { get; set; }

		public PointColor()
		{
			X = 0.0;
			Y = 0.0;
			Color = DoubleColor.BlackColor();
		}

		public PointColor(double x, double y, DoubleColor color)
		{
			X = x;
			Y = y;
			Color = color;
		}
	}
}
