using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GradientX : TransformParent
	{
		int _alpha;
		Gradient _gradient;

		public GradientX()
		{
			_alpha = RandomNumberProvider.GetInt(256);
			_gradient = new Gradient();
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;

			inX = inX % 1.0;
			inX = Math.Abs(inX);

			Color outColor = _gradient.GetColorAtValue(inX);

			input.Color = Color.FromArgb(_alpha, outColor.R, outColor.G, outColor.B);

			return input;
		}
	}
}