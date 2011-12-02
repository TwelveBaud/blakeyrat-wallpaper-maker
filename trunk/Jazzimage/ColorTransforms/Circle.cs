using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class Circle : TransformParent
	{
		protected double _circleRadius;
		protected Color _circleColor;

		public Circle()
		{
			_circleRadius = NumberUtils.GetRandDouble();
			_circleColor = ColorUtils.GetRandomColor();
			_circleColor = Color.FromArgb(NumberUtils.GetRandInt(256), _circleColor.R, _circleColor.G, _circleColor.B);
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			inX = inX % 1.0;
			inY = inY % 1.0;

			double dist = Math.Sqrt(Math.Pow(inX, 2.0) + Math.Pow(inY, 2.0));
			if (dist < _circleRadius)
			{
				input.Color = ColorUtils.Combine(input.Color, _circleColor);
			}

			return input;
		}
	}
}
