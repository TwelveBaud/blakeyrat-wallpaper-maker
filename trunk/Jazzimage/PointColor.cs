using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	public class PointColor
	{
		protected double _x;
		protected double _y;
		protected Color _color;

		public PointColor()
		{
			_x = 0.0;
			_y = 0.0;
			_color = Color.Black;
		}

		public PointColor(double x, double y, Color color)
		{
			_x = x;
			_y = y;
			_color = color;
		}

		public double X
		{
			get { return _x; }
			set { _x = value; }
		}

		public double Y
		{
			get { return _y; }
			set { _y = value; }
		}

		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}
	}
}
