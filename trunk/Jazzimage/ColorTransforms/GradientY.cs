using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GradientY : TransformParent
	{
		int _alpha;
		Gradient _gradient;

		public GradientY()
		{
			_alpha = RandomNumberProvider.GetInt(256);
			_gradient = new Gradient();
		}

		public override PointColor Transform(PointColor input)
		{
			double inY = input.Y;

			inY = inY % 1.0;
			inY = Math.Abs(inY);

			Color outColor = _gradient.GetColorAtValue(inY);

			input.Color = Color.FromArgb(_alpha, outColor.R, outColor.G, outColor.B);

			return input;
		}
	}
}