using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GradientX : TransformParent
	{
		Gradient _gradient;

		public GradientX()
		{
			_gradient = new Gradient();
		}

		public override PointColor Transform(PointColor input)
		{
			var inX = input.X;

			inX = inX % 1.0;
			inX = Math.Abs(inX);

			var outColor = _gradient.GetColorAtValue(inX);

			input.Color = outColor;

			return input;
		}
	}
}