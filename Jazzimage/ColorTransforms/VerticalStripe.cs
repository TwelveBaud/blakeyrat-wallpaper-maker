using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class VerticalStripe : TransformParent
	{
		double _stripeWidth;
		DoubleColor _stripeColor;

		public VerticalStripe()
		{
			_stripeWidth = RandomNumberProvider.GetDouble() * 0.25;
			_stripeColor = DoubleColor.GetRandomColorAlpha();
			_stripeColor.A = _stripeColor.A / 2.0;
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;
			if (inX < 0)
			{
				inX = -inX + _stripeWidth;
			}

			if (inX % (_stripeWidth * 2) < _stripeWidth)
			{
				input.Color = DoubleColor.Combine(input.Color, _stripeColor);
			}

			return input;
		}
	}
}
