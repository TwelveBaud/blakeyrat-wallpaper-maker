using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class HorizontalStripe : TransformParent
	{
		protected double _stripeWidth;
		protected Color _stripeColor;

		public HorizontalStripe()
		{
			_stripeWidth = NumberUtils.GetRandDouble() * 0.25;
			_stripeColor = ColorUtils.GetRandomColor();
			_stripeColor = Color.FromArgb(NumberUtils.GetRandInt(256), _stripeColor.R, _stripeColor.G, _stripeColor.B);
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
				input.Color = ColorUtils.Combine(input.Color, _stripeColor);
			}

			return input;
		}
	}
}
