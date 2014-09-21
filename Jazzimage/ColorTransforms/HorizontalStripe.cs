using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class HorizontalStripe : TransformParent
	{
		double _stripeWidth;
		DoubleColor _stripeColor;

		public HorizontalStripe()
		{
			_stripeWidth = RandomNumberProvider.GetDouble() * 0.25;
			_stripeColor = DoubleColor.GetRandomColorAlpha();
			_stripeColor.A = _stripeColor.A / 2.0;
		}

		public override PointColor Transform(PointColor input)
		{
			double inY = input.Y;
			if (inY < 0)
			{
				inY = -inY + _stripeWidth;
			}

			if (inY % (_stripeWidth * 2) < _stripeWidth)
			{
				input.Color = DoubleColor.Combine(input.Color, _stripeColor);
			}

			return input;
		}
	}
}
