using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GradientY : TransformParent
	{
		Gradient _gradient;

		public GradientY()
		{
			_gradient = new Gradient();
		}

		public override PointColor Transform(PointColor input)
		{
			var inY = input.Y;

			inY = inY % 1.0;
			inY = Math.Abs(inY);

			var outColor = _gradient.GetColorAtValue(inY);

			input.Color = outColor;

			return input;
		}
	}
}