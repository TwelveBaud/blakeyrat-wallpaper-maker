using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class Circle : TransformParent
	{
		double _circleRadius;
		DoubleColor _circleColor;

		public Circle()
		{
			_circleRadius = RandomNumberProvider.GetDouble();
			_circleColor = DoubleColor.GetRandomColor();
			_circleColor.RandomizeAlpha();
			_circleColor.A = _circleColor.A / 2.0;
		}

		public override PointColor Transform(PointColor input)
		{
			var inX = input.X - 0.5;
			var inY = input.Y - 0.5;

			inX = inX % 1.0;
			inY = inY % 1.0;

			var dist = Math.Sqrt(Math.Pow(inX, 2.0) + Math.Pow(inY, 2.0));
			if (dist < _circleRadius)
			{
				input.Color = DoubleColor.Combine(input.Color, _circleColor);
			}

			return input;
		}
	}
}
