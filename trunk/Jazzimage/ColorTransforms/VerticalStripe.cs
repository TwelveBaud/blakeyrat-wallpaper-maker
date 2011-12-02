﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class VerticalStripe : TransformParent
	{
		protected double _stripeWidth;
		protected Color _stripeColor;

		public VerticalStripe()
		{
			_stripeWidth = NumberUtils.GetRandDouble() * 0.25;
			_stripeColor = ColorUtils.GetRandomColor();
			_stripeColor = Color.FromArgb(NumberUtils.GetRandInt(256), _stripeColor.R, _stripeColor.G, _stripeColor.B);
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
				input.Color = ColorUtils.Combine(input.Color, _stripeColor);
			}

			return input;
		}
	}
}
