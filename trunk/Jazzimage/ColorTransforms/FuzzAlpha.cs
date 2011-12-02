using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class FuzzAlpha : TransformParent
	{
		protected int _minValue;
		protected int _maxValue;

		public FuzzAlpha()
		{
			int value1 = NumberUtils.GetRandInt(256);
			int value2 = NumberUtils.GetRandInt(256);

			_minValue = Math.Min(value1, value2);
			_maxValue = Math.Max(value1, value2);
		}

		public override PointColor Transform(PointColor input)
		{
			int newAlpha = NumberUtils.GetRandInt(_maxValue - _minValue) + _minValue;

			input.Color = Color.FromArgb(newAlpha, input.Color.R, input.Color.G, input.Color.B);

			return input;
		}
	}
}
