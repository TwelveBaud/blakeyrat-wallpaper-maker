using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GradientCircle : TransformParent
	{
		Gradient _gradient;
		double _originX;
		double _originY;

		public GradientCircle()
		{
			_gradient = new Gradient();
			_originX = RandomNumberProvider.GetDouble();
			_originY = RandomNumberProvider.GetDouble();
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			inX = inX % 1.0;
			inY = inY % 1.0;

			double dist = Math.Sqrt(Math.Pow(inX - _originX, 2.0) + Math.Pow(inY - _originY, 2.0));

			dist = dist % 1.0;

			var outColor = _gradient.GetColorAtValue(dist);

			input.Color = outColor;

			return input;
		}
	}
}